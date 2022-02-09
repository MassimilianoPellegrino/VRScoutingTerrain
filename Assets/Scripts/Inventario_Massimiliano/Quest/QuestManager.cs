using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public delegate void OnItemPickedUp(Item item);
    public static OnItemPickedUp onItemPickedUpCallback;

    public static void IncreaseAmount(Item item)
    {
        if (onItemPickedUpCallback != null)
            onItemPickedUpCallback.Invoke(item);
    }
}
