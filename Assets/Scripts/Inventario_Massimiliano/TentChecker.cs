using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentChecker : MonoBehaviour
{
    public Item item;
    public float radius;
    public int sticksNeeded;
    bool gotCloth = false;
    bool gotNPC = false;

    public int CheckAround()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        List<Collider> sticks = new List<Collider>();
        Collider cloth = null;

        foreach (var hitCollider in hitColliders)
        {
            if ((hitCollider != null && hitCollider.GetComponent<ItemPickup>() != null
                && (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Wooden Stick")
                || hitCollider.GetComponent<ItemPickup>().item.name.Equals("Cloth"))) || hitCollider.CompareTag("NPC"))
            {
                if (hitCollider.CompareTag("NPC"))
                {
                    gotNPC = true;
                }
                else if (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Wooden Stick"))
                {
                    if (sticks.Count < sticksNeeded)
                    {
                        sticks.Add(hitCollider);
                    }
                }
                else if (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Cloth"))
                {
                    if (gotCloth == false)
                    {
                        gotCloth = true;
                        cloth = hitCollider;
                    }
                }
            }
        }


        if (sticks.Count == sticksNeeded && gotCloth && gotNPC)
        {
           Instantiation.instance.InstantiateTent(this.gameObject, sticks, cloth);
            return 1;
        }
        else if(sticks.Count == sticksNeeded && gotCloth)
        {
            return 0;
        }
        else
        {
            return -1;
        }

    }

}
