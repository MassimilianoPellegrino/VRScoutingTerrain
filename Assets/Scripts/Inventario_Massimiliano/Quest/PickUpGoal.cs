using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGoal : Goal
{

    public Item Item { get; set; }
    
    public PickUpGoal(Item item, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Item = item;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        QuestManager.onItemPickedUpCallback += RockPickedUp;
    }

    void RockPickedUp(Item item)
    {
        if (item.Equals(this.Item))
        {
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
