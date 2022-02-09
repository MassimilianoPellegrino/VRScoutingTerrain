using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentQuest : MyQuest
{
    public Item TentMedal;
    public Item Tent;

    // Start is called before the first frame update
    void Start()
    {
        QuestName = "Monta la tenda";
        Description = "Trova dei rami lunghi e posiziona il telo";
        Medal = TentMedal;

        Goals.Add(new InstantiateGoal(this, Tent, "Monta la tenda", false, 0, 1));

        Goals.ForEach(g => g.Init());
    }
}
