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

    public Item cloth;

    //public float TentForward;
    //public float FireForward;

    public Transform NPC;
    Transform TentPosition;
    Transform FirePosition;

    public float spawnHeight;

    private void Start()
    {
        TentPosition = NPC.GetChild(0);
        FirePosition = TentPosition.GetChild(0);

    }


    public void Spawn(Item item)
    {
        callFromInventory = true;

        if(item.Equals(cloth))
            Instantiate(item.prefab, new Vector3(Random.Range(player.transform.position.x - 1f, player.transform.position.x + 1f), player.transform.position.y - spawnHeight, Random.Range(player.transform.position.z + 4f, player.transform.position.z + 6f)), item.prefab.transform.rotation);
        else
            Instantiate(item.prefab, new Vector3(Random.Range(player.transform.position.x -2f, player.transform.position.x +2f), player.transform.position.y - spawnHeight, Random.Range(player.transform.position.z + 1f, player.transform.position.z + 4f)), item.prefab.transform.rotation);
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
        if(GetComponent<FireQuest>().enabled)
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

            //var fire = Instantiate(bonefire, new Vector3(player.transform.position.x + 2f, 0.5f, player.transform.position.z + FireForward), bonefire.transform.rotation);

            var fire = Instantiate(bonefire, FirePosition.position, bonefire.transform.rotation);

            if (fire.GetComponent<AssignItem>() != null)
            {
                QuestManager.MakeBonfire(fire.GetComponent<AssignItem>().item);
            }
        }
    }

    public void InstantiateTent(GameObject go, List<Collider> sticks, Collider cloth)
    {
        if (GetComponent<TentQuest>().enabled) 
        {
            Destroy(go);

            foreach (var stick in sticks)
            {
                Destroy(stick.gameObject);
            }

            Destroy(cloth.gameObject);

            //var hut = Instantiate(tent, new Vector3(player.transform.position.x + 2f, 0f, player.transform.position.z + TentForward), tent.transform.rotation);

            var hut = Instantiate(tent, TentPosition.position, tent.transform.rotation);

            if (hut.GetComponent<AssignItem>() != null)
            {
                QuestManager.MakeBonfire(hut.GetComponent<AssignItem>().item);
            }
        }
    }
}
