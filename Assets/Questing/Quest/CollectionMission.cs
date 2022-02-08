using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionMission : Goals
{
     //nel tutorial sarebbe la missione di raccolta
     public int ItemID {get; set;} //anche string

    public CollectionMission(Quest quest, int itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;

    }

    public override void Init()
    {
        base.Init();
        //UIEventHandler.OnItemAddedToInventory += ItemPickedUp
        //Massimo in questa funzione bisogna dire che ha preso l'oggetto
        //Ci serve un evento, lui fa l'esempio della morte di un personaggio
    }

   /* void ItemPickedUp(Item item)
    {
        if(item.ObjectSlug == this.itemID)
        {
            this.CurrentAmount ++;
            Evaluate();
        }
    } */ // qui mi dava errore, va fatta funzionare con il picker che hai creato
}