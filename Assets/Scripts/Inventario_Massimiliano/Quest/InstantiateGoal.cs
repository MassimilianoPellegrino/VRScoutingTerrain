using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGoal : Goal
{

    public Item Item { get; set; }
    
    public InstantiateGoal(MyQuest quest, Item item, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.Item = item;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        QuestManager.onItemInstantiatedCallback += FireMade;
    }

    void FireMade(Item item)
    {
        if (item.Equals(this.Item))
        {
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
