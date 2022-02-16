using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDetected : MonoBehaviour
{
    public string[] avvisoTenda;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MyDialogueSystem.Instance.AddNewDialogue(avvisoTenda);
        }
    }

}
