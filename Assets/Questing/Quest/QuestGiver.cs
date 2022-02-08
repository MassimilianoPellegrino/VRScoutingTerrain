using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest {get; set;}
    public bool Helped {get; set;}
    [SerializeField] private GameObject quests;
    [SerializeField] private string questType;
    private Quest Quest {get; set;}

    public override void Interact()
    {
        if (!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        } else if(AssignedQuest && !Helped)
        {
            CheckQuest();
        } else
        {
        DialogueSystem.Instance.AddNewDialogue(new string[] {"GRAZIE"}, name);
        }

    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));    
    }
    void CheckQuest()
    {
        if(Quest.Completed)
        {
            //Quest.GiveReward(); metodo di consegnaa della ricompensa richiamato da quest
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] {"Thanks for that! Here's your reward", "More"}, name);       
        } else
        { 
           DialogueSystem.Instance.AddNewDialogue(new string[] {"You are still in the middle. Get back at hit!", "More"}, name);
        }
    }
}
