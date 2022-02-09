using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public GameObject player;
    private bool hasInteracted;

    private void Update()
    {
        if (!hasInteracted && Input.GetKeyDown(KeyCode.E) && Interaction.PointingNPC != null)
        {
            Interact();
            hasInteracted = true;
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
