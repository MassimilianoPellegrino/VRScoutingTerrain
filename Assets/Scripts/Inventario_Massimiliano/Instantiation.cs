using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    #region Singleton

    public static Instantiation instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Diary found!");
            return;
        }

        instance = this;
    }

    #endregion

    public GameObject player;
    static bool callFromInventory;
    public GameObject bonefire;
    public GameObject tent;

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

    public void InstantiateBonefire(GameObject go, List<Collider> rocks, List<Collider> branches)
    {

        Destroy(go);

        foreach (var rock in rocks)
        {
            Destroy(rock.gameObject);
        }
        foreach (var branch in branches)
        {
            Destroy(branch.gameObject);
        }

        var fire = Instantiate(bonefire, new Vector3(player.transform.position.x +2f, 0.5f, player.transform.position.z + 4f), bonefire.transform.rotation);

        if (fire.GetComponent<AssignItem>() != null)
        {
            QuestManager.MakeBonfire(fire.GetComponent<AssignItem>().item);
        }
    }

    public void InstantiateTent(GameObject go, List<Collider> sticks, Collider cloth)
    {

        Destroy(go);

        foreach (var stick in sticks)
        {
            Destroy(stick.gameObject);
        }

        Destroy(cloth.gameObject);

        Instantiate(tent, new Vector3(player.transform.position.x + 2f, 0f, player.transform.position.z + 4f), bonefire.transform.rotation);
    }
}
