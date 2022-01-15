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
}
