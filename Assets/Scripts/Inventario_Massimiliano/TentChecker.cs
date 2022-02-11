using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentChecker : MonoBehaviour
{
    public Item item;
    public float radiusItems;
    public float radiusNPC;
    public int sticksNeeded;
    bool gotCloth = false;
    bool gotNPC = false;

    public int CheckAround()
    {

        Collider[] hitItems = Physics.OverlapSphere(transform.position, radiusItems);
        Collider[] hitNPCs = Physics.OverlapSphere(transform.position, radiusNPC);

        List<Collider> sticks = new List<Collider>();
        Collider cloth = null;

        foreach (var hitItem in hitItems)
        {
            if (hitItem != null && hitItem.GetComponent<ItemPickup>() != null
                && (hitItem.GetComponent<ItemPickup>().item.name.Equals("Wooden Stick")
                || hitItem.GetComponent<ItemPickup>().item.name.Equals("Cloth")))
            {
                if (hitItem.CompareTag("NPC"))
                {
                    gotNPC = true;
                }
                else if (hitItem.GetComponent<ItemPickup>().item.name.Equals("Wooden Stick"))
                {
                    if (sticks.Count < sticksNeeded)
                    {
                        sticks.Add(hitItem);
                    }
                }
                else if (hitItem.GetComponent<ItemPickup>().item.name.Equals("Cloth"))
                {
                    if (gotCloth == false)
                    {
                        gotCloth = true;
                        cloth = hitItem;
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
