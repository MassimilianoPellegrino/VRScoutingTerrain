using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonefireChecker : MonoBehaviour
{
    public Item item;
    public float radius;
    public int rocksNeeded;
    public int branchesNeeded;
    bool gotNPC = false;

    List<Collider> rocks;
    List<Collider> branches;


    public int CheckAround()
    {
               
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        rocks = new List<Collider>();
        branches = new List<Collider>();


        foreach (var hitCollider in hitColliders)
        {
            if ((hitCollider != null && hitCollider.GetComponent<ItemPickup>() != null 
                && (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Branch") 
                || hitCollider.GetComponent<ItemPickup>().item.name.Equals("Rock"))) || hitCollider.CompareTag("NPC"))
            {
                if (hitCollider.CompareTag("NPC"))
                {
                    gotNPC = true;
                }
                else if (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Branch"))
                {
                    if (branches.Count < branchesNeeded)
                    {
                        branches.Add(hitCollider);                        
                    }
                }
                else if (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Rock"))
                {
                    if (rocks.Count < rocksNeeded)
                    {
                        rocks.Add(hitCollider);
                    }
                }
            }
        }

        if (rocks.Count == rocksNeeded && branches.Count == branchesNeeded && gotNPC)
        {
            Instantiation.instance.InstantiateBonefire(this.gameObject, rocks, branches);
            return 1;
        }
        else if(rocks.Count == rocksNeeded && branches.Count == branchesNeeded)
        {
            return 0;
        }
        else
        {
            return -1;
        }
           
    }

}
