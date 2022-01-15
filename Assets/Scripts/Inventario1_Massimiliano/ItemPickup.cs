using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public string nome;

    private void Start()
    {
        item.quantity = 0;
    }

    void Update()
    {
        if (Interaction.PointingItem != null)
            PickUp();
    }
    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Interaction.PointingItem.CompareTag("Terrain") && name == Interaction.PointingItem.name)
        {
            bool wasPickedUp = Inventory.instance.Add(item);

            if (wasPickedUp)
                Destroy(Interaction.PointingItem.gameObject);
        }
    }
}
