using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersQuest : MyQuest
{
    public Item FlowerMedal;
    public Item Flower;

    // Start is called before the first frame update
    void Start()
    {
        QuestName = "Cataloga i fiori";
        Description = "Trova qualche fiore e raccogli le informazioni sul diario";
        Medal = FlowerMedal;
        Goals.Add(new CollectGoal(this, Flower, "Cataloga i fiori", false, 0, 4));

        Goals.ForEach(g => g.Init());
    }
}
