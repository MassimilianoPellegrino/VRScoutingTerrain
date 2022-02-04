using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public string nome;

    private void Start()
    {
        if (!Instantiation.CalledFromInventory())
        {
            item.quantity = 0;
        }
    }

    void Update()
    {
        if (Interaction.PointingItem != null)
            PickUp();
        if (item.toPlaceInHand)
            PutBackInInventory();

    }
    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Interaction.PointingItem.CompareTag("Terrain") 
            && name == Interaction.PointingItem.name && !HandsOccupied.handsOccupied)
        {
            bool wasPickedUp = Inventory.instance.Add(item);

            if (wasPickedUp)
                Destroy(Interaction.PointingItem.gameObject);
        }
    }
    void PutBackInInventory()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {


            bool wasPickedUp = Inventory.instance.Add(item);

            if (wasPickedUp)
            {
                HandsOccupied.handsOccupied = false;
                Destroy(gameObject);
            }
        }
    }
}
