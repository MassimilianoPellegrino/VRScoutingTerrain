using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNPC : InteractableNPC
{
    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacting with NPC.");
        }
    }
}
