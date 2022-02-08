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
        if (Interaction.PointingItem != null && !Interaction.item.isFlower)
            PickUp();
        if (item.toPlaceInHand)
            PutBackInInventory();
        if (Interaction.PointingItem != null && (Interaction.item.isFlower || Interaction.item.isConstellation))
            ShowInfoOnDiary();
   
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

    void ShowInfoOnDiary()
    {
        if (((Input.GetKeyDown(KeyCode.F) && Interaction.item.isFlower) || (Input.GetMouseButtonDown(0) && Interaction.item.isConstellation)) 
            && !Interaction.PointingItem.CompareTag("Terrain")
            && name == Interaction.PointingItem.name 
            && !HandsOccupied.handsOccupied && !Diary.DiarioON)
        {
            bool pageAdded = Diary.instance.Add(item);

            if (pageAdded)
            {
                Diary.instance.ShowDiary();
            }
        }
    }


}
