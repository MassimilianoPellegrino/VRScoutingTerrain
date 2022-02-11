using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTent : MonoBehaviour
{
    static bool ropeInScene;

    MyQuest TentQuest;

    void Start()
    {
        ropeInScene = true;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Manager"))
        {
            if (go.name == "GameManager")
            {
                TentQuest = go.GetComponent<TentQuest>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TentQuest.enabled && Input.GetKeyDown(KeyCode.Q) && Interaction.PointingItem != null &&
            (Interaction.PointingItem.GetComponent<ItemPickup>().item.name.Equals("Wooden Stick")
                || Interaction.PointingItem.GetComponent<ItemPickup>().item.name.Equals("Cloth")))
        {
            int tentMade = Interaction.PointingItem.GetComponent<TentChecker>().CheckAround();
            if (tentMade == -1)
            {
                Interaction.DisplayWarning("AvvisoTenda");
            }
            if(tentMade == 0)
            {
                Interaction.DisplayWarning("AvvisoNPC");
            }

        }
    }

    public static bool RopeIsInHand()
    {
        return ropeInScene;
    }
}
