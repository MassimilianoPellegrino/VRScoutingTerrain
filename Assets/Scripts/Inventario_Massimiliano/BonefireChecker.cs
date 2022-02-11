using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonefireChecker : MonoBehaviour
{
    public Item item;
    public float radiusItems;
    public float radiusNPC;
    public int rocksNeeded;
    public int branchesNeeded;
    bool gotNPC = false;

    List<Collider> rocks;
    List<Collider> branches;


    public int CheckAround()
    {
               
        Collider[] hitItems = Physics.OverlapSphere(transform.position, radiusItems);
        Collider[] hitNPCs = Physics.OverlapSphere(transform.position, radiusNPC);


        rocks = new List<Collider>();
        branches = new List<Collider>();


        foreach (var hitItem in hitItems)
        {
            if (hitItem != null && hitItem.GetComponent<ItemPickup>() != null 
                && (hitItem.GetComponent<ItemPickup>().item.name.Equals("Branch") 
                || hitItem.GetComponent<ItemPickup>().item.name.Equals("Rock")))
            {
                if (hitItem.CompareTag("NPC"))
                {
                    gotNPC = true;
                }
                else if (hitItem.GetComponent<ItemPickup>().item.name.Equals("Branch"))
                {
                    if (branches.Count < branchesNeeded)
                    {
                        branches.Add(hitItem);                        
                    }
                }
                else if (hitItem.GetComponent<ItemPickup>().item.name.Equals("Rock"))
                {
                    if (rocks.Count < rocksNeeded)
                    {
                        rocks.Add(hitItem);
                    }
                }
            }
        }

        foreach(var hitNPC in hitNPCs)
        {
            if (hitNPC.CompareTag("NPC"))
            {
                gotNPC = true;
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
