using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public GameObject player;

    public virtual void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacting with base class.");
        }
    }
}
