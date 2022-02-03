using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonefireChecker : MonoBehaviour
{
    public Item item;
    public float radius;
    public GameObject bonefire;
    public int rocksNeeded;
    public int branchesNeeded;
    
    public bool CheckAround()
    {
               
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        List<Collider> rocks = new List<Collider>();
        List<Collider> branches = new List<Collider>();


        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider != null && hitCollider.GetComponent<ItemPickup>() != null 
                && (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Branch") 
                || hitCollider.GetComponent<ItemPickup>().item.name.Equals("Rock")))
            {
                if (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Branch"))
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

        
        if(rocks.Count == rocksNeeded && branches.Count == branchesNeeded)
        {
            InstantiateBonefire(rocks, branches);
            return true;
        }
        else
        {
            return false;
        }
           
    }

    void InstantiateBonefire(List<Collider> rocks, List<Collider> branches)
    {
        
        Destroy(gameObject);

        foreach (var rock in rocks)
        {
            Destroy(rock.gameObject);
        }
        foreach (var branch in branches)
        {
            Destroy(branch.gameObject);
        }

        Instantiate(bonefire, new Vector3(transform.position.x, 0.5f, transform.position.z+2f), bonefire.transform.rotation);
    }
}
