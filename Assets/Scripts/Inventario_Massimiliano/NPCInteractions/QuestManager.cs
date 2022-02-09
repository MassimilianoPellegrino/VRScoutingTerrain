using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public delegate void OnItemInstatiated(Item item);
    public delegate void OnItemCollected(Item item);


    public static OnItemInstatiated onItemInstantiatedCallback;
    public static OnItemCollected onItemCollectedCallback;

    public static void MakeBonfire(Item bonfire)
    {
        if (onItemInstantiatedCallback != null)
        {
            onItemInstantiatedCallback.Invoke(bonfire);
        }
    }
    public static void IncreaseItem(Item item)
    {

        if (onItemCollectedCallback != null)
        {
            onItemCollectedCallback.Invoke(item);
        }
    }
}
