using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNPC : MonoBehaviour
{
    private string[] dialogue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Interaction.PointingNPC != null)
        {
            Interact();
        }
    }

    public void AssignDialogue(string[] dialogue)
    {
        this.dialogue = dialogue;
    }

    public virtual void Interact()
    {
        MyDialogueSystem.Instance.AddNewDialogue(dialogue);
    }
}
