using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public GameObject GameManager;

    public int space = 15;

    public List<Item> items = new List<Item>();

    public Text handsWarning;
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Contains(item))
            {
                Debug.Log("Ma che fai");
                item.quantity++;
            }
            else if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            else
            {
                items.Add(item);
                item.quantity++;
            }

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        if(!item.prefab.CompareTag("InHand"))
            GameManager.GetComponent<Instantiation>().Spawn(item);
        else
            GameManager.GetComponent<Instantiation>().SpawnInHand(item);

        if (item.quantity == 1)
            items.Remove(item);

        item.quantity--;
                
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
             
        
    }

    public void DisplayHandsWarning()
    {
        handsWarning.GetComponent<Text>().enabled = true;
    }

}
