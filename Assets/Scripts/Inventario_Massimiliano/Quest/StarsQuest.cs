using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsQuest : MyQuest
{
    public Item StarMedal;
    public Item Star;

    // Start is called before the first frame update
    void Start()
    {
        QuestName = "Cataloga le costellazioni";
        Description = "Trova le costellazioni in cielo raccogli le informazioni sul diario";
        Medal = StarMedal;
        Goals.Add(new CollectGoal(this, Star, "Cataloga le costellazioni", false, 0, 5));

        Goals.ForEach(g => g.Init());
    }
}
