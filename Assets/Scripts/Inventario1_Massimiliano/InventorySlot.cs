using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Image quantity;

    Item item;
    

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        quantity.GetComponentInChildren<Text>().text = item.quantity.ToString();
        quantity.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
}
