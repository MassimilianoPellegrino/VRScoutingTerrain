using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MyQuest : MonoBehaviour
{
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public Item Medal { get; set; }
    public bool Completed { get; set; }

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
        if (Completed) GiveReward();
    }

    void GiveReward()
    {
        if(Medal != null)
        {
            Diary.instance.GiveMedal(Medal);
        }
    }


}
