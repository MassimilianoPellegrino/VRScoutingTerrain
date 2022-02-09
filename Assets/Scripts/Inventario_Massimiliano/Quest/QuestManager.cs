using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public delegate void OnItemInstatiated(Item item);
    public static OnItemInstatiated onItemInstantiatedCallback;

    public static void MakeBonfire(Item bonfire)
    {
        if (onItemInstantiatedCallback != null)
        {
            onItemInstantiatedCallback.Invoke(bonfire);
        }
    }
}
