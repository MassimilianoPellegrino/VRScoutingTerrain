using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksGoal : Goal
{

    public Item Rock { get; set; }
    
    public RocksGoal(Item rock, string description, bool completed, int requiredAmount)
    {
        this.Rock = rock;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = rock.quantity;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        QuestManager.onItemPickedUpCallback += RockPickedUp;
    }

    void RockPickedUp(Item item)
    {
        if (item.Equals(Rock))
        {
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
