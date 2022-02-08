using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFire: Quest
{
    //nel tutorial sarebbbe l'uccisione Ultimate Slasher
   
    void Start()
    {
        QuestName = "Create Fire"; 
        Description ="Use wood and rocks for making fire";
      //ItemReward = ItemDatabase.Instance.GetItem("fire"); dallo stesso posto dove esce il fuoco
        
        GoalList.Add(new JobDone(this, 0, "Create fire", false, 0, 1));
        //aggiungere raccolta

        GoalList.ForEach(g => g.Init());



    }

}
