using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory1
{
    private List<Item1> itemList;

    public Inventory1()
    {
        itemList = new List<Item1>();

        AddItem(new Item1 {itemType = Item1.ItemType.Pietra, amount = 1});
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item1 item)
    {
        itemList.Add(item);
    }
}
