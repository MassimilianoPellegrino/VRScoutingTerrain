using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBonefire : MonoBehaviour
{
    static bool lighterInScene;

    MyQuest FireQuest;

    void Start()
    {
        lighterInScene = true;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Manager"))
        {
            FireQuest = go.GetComponent<FireQuest>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FireQuest.enabled && Input.GetKeyDown(KeyCode.Q) && Interaction.PointingItem != null &&
            (Interaction.PointingItem.GetComponent<ItemPickup>().item.name.Equals("Branch")
                || Interaction.PointingItem.GetComponent<ItemPickup>().item.name.Equals("Rock")))
        {
            int bonfireSet = Interaction.PointingItem.GetComponent<BonefireChecker>().CheckAround();
            if (bonfireSet == -1)
            {
                Interaction.DisplayWarning("AvvisoFuoco");
            }
            else if(bonfireSet == 0)
            {
                Interaction.DisplayWarning("AvvisoNPC");
            }

        }
    }

    public static bool LighterIsInHand()
    {
        return lighterInScene;
    }
}
