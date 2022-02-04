using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentChecker : MonoBehaviour
{
    public Item item;
    public float radius;
    public GameObject tent;
    public int sticksNeeded;
    bool gotCloth = false;

    public bool CheckAround()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        List<Collider> sticks = new List<Collider>();
        Collider cloth = null;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider != null && hitCollider.GetComponent<ItemPickup>() != null
                && (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Wooden Stick")
                || hitCollider.GetComponent<ItemPickup>().item.name.Equals("Cloth")))
            {
                if (hitCollider.GetComponent<ItemPickup>().item.name.Equals("Wooden Stick"))
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


        if (sticks.Count == sticksNeeded && gotCloth)
        {
            InstantiateTent(sticks, cloth);
            return true;
        }
        else
        {
            return false;
        }

    }

    void InstantiateTent(List<Collider> sticks, Collider cloth)
    {

        Destroy(gameObject);

        foreach (var stick in sticks)
        {
            Destroy(stick.gameObject);
        }

        Destroy(cloth.gameObject);

        Instantiate(tent, new Vector3(transform.position.x, 0f, transform.position.z + 2f), tent.transform.rotation);
    }
}
