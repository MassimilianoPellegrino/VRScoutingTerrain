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
        if (Input.GetKeyDown(KeyCode.Q) && Interaction.PointingItem != null)
        {
            bool bonfireSet = Interaction.PointingItem.GetComponent<BonefireChecker>().CheckAround();
            if (!bonfireSet)
            {
                Interaction.DisplayBonfireWarning();
            }

        }
    }

    public static bool LighterIsInHand()
    {
        return lighterInScene;
    }
}
