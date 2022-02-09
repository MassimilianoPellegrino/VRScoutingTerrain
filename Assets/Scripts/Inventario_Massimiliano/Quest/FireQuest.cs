using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireQuest : MyQuest
{
    public Item FireMedal;
    public Item Rock;
    public Item Branch;
    public BonefireChecker fireInfo;

    // Start is called before the first frame update
    void Start()
    {
        QuestName = "Accendi il fuoco";
        Description = "Trova alcuni rami e alcune rocce per accendere il fuoco";
        Medal = FireMedal;
        Goals.Add(new PickUpGoal(Rock, "Trova alcune rocce", false, 0, fireInfo.rocksNeeded));
        Goals.Add(new PickUpGoal(Branch, "Trova alcuni rami", false, 0, fireInfo.branchesNeeded));

        Goals.ForEach(g => g.Init());
    }

}
