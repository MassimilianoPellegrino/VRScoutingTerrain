using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNPC : InteractableNPC
{
    public string[] dialogue;

    public override void Interact()
    {
        MyDialogueSystem.Instance.AddNewDialogue(dialogue);
        Debug.Log("Interacting with NPC.");
    }
}
