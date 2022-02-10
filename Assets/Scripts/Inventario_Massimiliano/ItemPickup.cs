using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public string nome;

    MyQuest FlowersQuest;
    MyQuest StarsQuest;

    private void Start()
    {
        if (!Instantiation.CalledFromInventory())
        {
            item.quantity = 0;
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Manager"))
        {
            if (go.name == "GameManager")
            {
                FlowersQuest = go.GetComponent<FlowersQuest>();
                StarsQuest = go.GetComponent<StarsQuest>();
            }

        }


    }

    void Update()
    {
        if (Interaction.PointingItem != null && !Interaction.item.isFlower)
            PickUp();
        if (item.toPlaceInHand)
            PutBackInInventory();
        if (Interaction.PointingItem != null && ((Interaction.item.isFlower && FlowersQuest != null && FlowersQuest.enabled) || (Interaction.item.isConstellation && StarsQuest != null && StarsQuest.enabled)))
            ShowInfoOnDiary();
   
    }
    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Interaction.PointingItem.CompareTag("Terrain") 
            && this.gameObject.Equals(Interaction.PointingItem.gameObject) && !HandsOccupied.handsOccupied)
        {
            bool wasPickedUp = Inventory.instance.Add(item);

            if (wasPickedUp)
            {
                Destroy(Interaction.PointingItem.gameObject);
            }
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
                if (Interaction.PointingItem.GetComponent<AssignItem>() != null)
                {
                    QuestManager.IncreaseItem(Interaction.PointingItem.GetComponent<AssignItem>().item);
                }

                Diary.instance.ShowDiary();
            }
        }
    }


}
