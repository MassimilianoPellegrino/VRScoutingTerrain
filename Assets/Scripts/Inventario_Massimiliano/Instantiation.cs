using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{

    public GameObject player;

    public void Spawn(Item item)
    {
        Instantiate(item.prefab, player.transform.position + (player.transform.forward * 2), item.prefab.transform.rotation);      
    }
    public void SpawnInHand(Item item)
    {
        GameObject itemInHand = Instantiate(item.prefab, player.transform.Find("ObjectInHand").position, item.prefab.transform.rotation);
        itemInHand.transform.SetParent(player.transform);
    }
}
