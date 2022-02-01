using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonefireChecker : MonoBehaviour
{
    public Item item;
    public float radius;
    bool rock;
    public GameObject bonefire;
    public int rocksNeeded;
    public int branchesNeeded;
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Interaction.PointingItem != null)
            CheckAround();
    }

    void CheckAround()
    {
        
        if (item.name.Equals("Branch"))
        {
            rock = false;
        }
        else if (item.name.Equals("Rock"))
        {
            rock = true;
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        List<Collider> rocks = new List<Collider>();
        List<Collider> branches = new List<Collider>();


        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider != null && !hitCollider.CompareTag("Terrain") && !hitCollider.name.Equals("RigidBodyFPSController"))
            {
                if (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Branch"))
                {
                    if ((rock && branches.Count < branchesNeeded) || (!rock && branches.Count < branchesNeeded - 1))
                        branches.Add(hitCollider);
                }
                else if (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Rock"))
                {
                    if ((rock && rocks.Count < rocksNeeded - 1) || (!rock && branches.Count < branchesNeeded))
                        rocks.Add(hitCollider);
                }
            }
        }

        
        if((rock && rocks.Count>=rocksNeeded-1 && branches.Count >= branchesNeeded) 
            || (!rock && rocks.Count >= rocksNeeded && branches.Count >= branchesNeeded - 1))
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

        Instantiate(bonefire, transform.position + (transform.forward * 2), transform.rotation);
    }
}
