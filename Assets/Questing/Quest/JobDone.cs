using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobDone : Goals
{
   //classe sotto Goals, quando hai completato il lavoro
    public int ObjectID {get; set;}

    public JobDone(Quest quest, int objectID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ObjectID = objectID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;

    }

    public override void Init()
    {
        base.Init();
        //AppearEvents.OnAppear += ObjectAppeared;
        //Massimo in questa funzione bisogna dire che il fuoco e' apparso
        //Ci serve un evento, lui fa l'esempio della morte di un personaggio
    }

    void ObjectAppeared(MissionObject missionObjects)
    {
        if(missionObjects.ID == this.ObjectID)
        {
            this.CurrentAmount ++;
            Evaluate();
        }
    }


}
