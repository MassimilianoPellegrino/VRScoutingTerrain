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

        if (item.quantity > 1)
        {
            quantity.GetComponentInChildren<Text>().text = item.quantity.ToString();
            quantity.enabled = true;
        }
        else
        {
            quantity.GetComponentInChildren<Text>().text = null;
            quantity.enabled = false;
        }

        
    }

    public void ClearSlot()
    {
        
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        quantity.enabled = false;

        quantity.GetComponentInChildren<Text>().text = null;
       
    }

    public void OnClickButton()
    {
        if (item != null)
        {
            Inventory.instance.Remove(item);
        }
            
    }
}
