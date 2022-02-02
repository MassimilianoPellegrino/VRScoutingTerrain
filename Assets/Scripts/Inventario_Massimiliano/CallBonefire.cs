using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBonefire : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Interaction.PointingItem != null)
        {
            Interaction.PointingItem.GetComponent<BonefireChecker>().CheckAround();
        }
    }
}
