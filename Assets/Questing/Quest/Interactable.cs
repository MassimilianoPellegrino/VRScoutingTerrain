using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
   //legarlo al sistema di interazione tuo
   [HideInInspector]
    public UnityEngine.AI.NavMeshAgent playerAgent;
  

    public virtual void MoveToInteraction(UnityEngine.AI.NavMeshAgent playerAgent)
    {
      
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = this.transform.position;
        Interact();   
    }
    
    public virtual void Interact()
    {
        
    }
}