using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{

    public GameObject player;
    static bool callFromInventory;

    public void Spawn(Item item)
    {
        callFromInventory = true;
        Instantiate(item.prefab, player.transform.position + (player.transform.forward * 2), item.prefab.transform.rotation);
    }
    public void SpawnInHand(Item item)
    {
        GameObject itemInHand = Instantiate(item.prefab, player.transform.Find("ObjectInHand").position, item.prefab.transform.rotation);
        itemInHand.transform.SetParent(player.transform);
    }

    public static bool CalledFromInventory()
    {
        return callFromInventory;
    }
}
