using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBonefire : MonoBehaviour
{
    static bool lighterInScene;

    void Start()
    {
        lighterInScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Interaction.PointingItem != null &&
            (Interaction.PointingItem.GetComponent<ItemPickup>().item.name.Equals("Branch")
                || Interaction.PointingItem.GetComponent<ItemPickup>().item.name.Equals("Rock")))
        {
            bool bonfireSet = Interaction.PointingItem.GetComponent<BonefireChecker>().CheckAround();
            if (!bonfireSet)
            {
                Interaction.DisplayWarning("AvvisoFuoco");
            }

        }
    }

    public static bool LighterIsInHand()
    {
        return lighterInScene;
    }
}
