using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{

    public GameObject player;

    public void Spawn(Item item)
    {
        Instantiate(item.prefab, player.transform.position + (player.transform.forward * 2), player.transform.rotation);      
    }
    public void SpawnInHand(Item item)
    {
        GameObject lighter = Instantiate(item.prefab, player.transform.Find("ObjectInHand").position, player.transform.rotation);
        lighter.transform.SetParent(player.transform);
    }
}
