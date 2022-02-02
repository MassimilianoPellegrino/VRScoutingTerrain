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


    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q) && Interaction.PointingItem != null)
            CheckAround();*/
    }

    public void CheckAround()
    {
        
        if (item.name.Equals("Branch"))
        {
            branchesNeeded--;
        }
        else if (item.name.Equals("Rock"))
        {
            rocksNeeded--;
        }

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
                        Debug.Log("Branch");
                    }
                }
                else if (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Rock"))
                {
                    if (rocks.Count < rocksNeeded)
                    {
                        rocks.Add(hitCollider);
                        Debug.Log("Rock");
                    }
                }
            }
        }

        
        if(rocks.Count>=rocksNeeded && branches.Count >= branchesNeeded)
        {
            InstantiateBonefire(rocks, branches); 
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

        //Instantiate(bonefire, transform.position + transform.forward*2 - transform.up*2, bonefire.transform.rotation);
        Instantiate(bonefire, new Vector3(transform.position.x, 0.5f, transform.position.z+2f), bonefire.transform.rotation);
    }
}
