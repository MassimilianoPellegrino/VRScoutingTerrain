using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MyQuestGiver : MyNPC
{
    public bool AssignedQuest { get; set; }
    //public bool Helped { get; set; }

    [SerializeField] private GameObject GameManager;

    private MyQuest Quest { get; set; }

    public MyQuest[] Quests;

    private int questIndex = -1;

    [HideInInspector] public bool AllQuestsCompleted;

    AnimationScript animationScript;

    public string[] indicazioniIniziali;
    public string[] fineMissione;
    public string[] dialogoFineGioco;

    public AudioSource GuideSound;

    private void Start()
    {
        MyDialogueSystem.Instance.AddNewDialogue(indicazioniIniziali);
        animationScript = GetComponent<AnimationScript>();
    }

    public override void Interact()
    {

        GuideSound.Play();

        if(!AssignedQuest && questIndex < Quests.Length-1 )
        {
            questIndex++;
            Quests[questIndex].enabled = true;
            base.AssignDialogue(Quests[questIndex].IntroductionDialogue);
            base.Interact();
            AssignQuest();
        }
        else if(AssignedQuest)
        {
            CheckQuest();
        }
        else if(questIndex == Quests.Length- 1)
        {
            MyDialogueSystem.Instance.AddNewDialogue(dialogoFineGioco);
            //MyDialogueSystem.Instance.AddNewDialogue(new string[] { "Congratulazione hai svolto tutti i tuoi compiti. Ora sei un vero esploratore!" });
            AllQuestsCompleted = true;
        }

    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = Quests[questIndex];
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward(questIndex);
            AssignedQuest = false;
            Quests[questIndex].enabled = false;
            MyDialogueSystem.Instance.AddNewDialogue(fineMissione);
            animationScript.StartInteracting3();
        }
        else
        {
            MyDialogueSystem.Instance.AddNewDialogue(Quests[questIndex].CheckDialogue);
            //MyDialogueSystem.Instance.AddNewDialogue(new string[] { "Non hai ancora completato il tuo compito" });
            animationScript.StartInteracting2();
        }
    }

    public int getQuestIndex()
    {
        return questIndex;
    }
}
