using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQuestGiver : MyNPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField] private GameObject GameManager;

    [SerializeField] private string questType;

    private MyQuest Quest { get; set; }

    public override void Interact()
    {
        if(!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        }
        else if(AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            MyDialogueSystem.Instance.AddNewDialogue(new string[] { "Ancora complimenti per il lavoro svolto" });
        }

    }

    void AssignQuest()
    {
        AssignedQuest = true;
        //Quest = (MyQuest)GameManager.AddComponent(System.Type.GetType(questType));
        GameManager.GetComponent <TentQuest>().enabled = true;
        Quest = GameManager.GetComponent<TentQuest>();
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            MyDialogueSystem.Instance.AddNewDialogue(new string[] {"Ottimo! Sei riuscito a montare la tenda"});
        }
        else
        {
            MyDialogueSystem.Instance.AddNewDialogue(new string[] { "Non hai ancora il materiale per mondare la tenda" });
        }
    }
}
