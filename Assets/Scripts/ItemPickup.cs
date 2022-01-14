using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Update()
    {
        if (Interaction.PointingItem != null)
            PickUp();
    }
    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Picking up" + item.name);
            bool wasPickedUp = Inventory.instance.Add(item);

            if(wasPickedUp)
                Destroy(Interaction.PointingItem.gameObject);
        }
    }
}
