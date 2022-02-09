using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireQuest : MyQuest
{
    public Item FireMedal;
    public Item Bonfire;

    // Start is called before the first frame update
    void Start()
    {
        QuestName = "Accendi il fuoco";
        Description = "Trova alcuni rami e alcune rocce per accendere il fuoco";
        Medal = FireMedal;
        Goals.Add(new InstantiateGoal(this, Bonfire, "Accendi il fuoco", false, 0, 1));

        Goals.ForEach(g => g.Init());
    }

}
