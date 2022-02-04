using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTent : MonoBehaviour
{
    static bool ropeInScene;

    void Start()
    {
        ropeInScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Interaction.PointingItem != null &&
            (Interaction.PointingItem.GetComponent<ItemPickup>().item.name.Equals("Wooden Stick")
                || Interaction.PointingItem.GetComponent<ItemPickup>().item.name.Equals("Cloth")))
        {
            bool tentMade = Interaction.PointingItem.GetComponent<TentChecker>().CheckAround();
            if (!tentMade)
            {
                Interaction.DisplayWarning("AvvisoTenda");
            }

        }
    }

    public static bool RopeIsInHand()
    {
        return ropeInScene;
    }
}
