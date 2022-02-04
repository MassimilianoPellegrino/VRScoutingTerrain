using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
   [SerializeField] private Image crosshair;

    public static Transform PointingItem = null;
    private bool isPointing = false;

    // Update is called once per frame
    void Update()
    {
        
        CheckAndMarkSelectable();
               

        if (!isPointing)
            UnmarkSelectable();
    }

    void CheckAndMarkSelectable()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f))
        {
            Transform pointing = hit.transform;

            if (pointing.CompareTag("Selectable"))
            {
                Item item = pointing.GetComponent<ItemPickup>().item;

                crosshair.GetComponent<Image>().color = Color.red;
                if (!CallBonefire.LighterIsInHand() && !CallTent.RopeIsInHand())
                {
                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiE")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                else if(CallBonefire.LighterIsInHand() && item.neededForBonfire)
                {
                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiQ_fuoco")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                else if (CallTent.RopeIsInHand() && item.neededForTent)
                {
                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiQ_tenda")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                PointingItem = pointing;
                isPointing = true;
            }
            else
            {
                PointingItem = null;
                isPointing = false;
            }

        }
        else
        {
            PointingItem = null;
            isPointing = false;
        }
        
    }
    void UnmarkSelectable()
    {
        crosshair.GetComponent<Image>().color = Color.white;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
        {
            //if (go.name == "PremiE" || go.name == "PremiQ" || go.name == "AvvisoFuoco")
                go.GetComponent<Text>().enabled = false;
        }
        PointingItem = null;
    }

    public static void DisplayWarning(string warning)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
        {
            /*if (go.name == "PremiE" || go.name == "PremiQ")
                go.GetComponent<Text>().enabled = false;*/
            if(go.name == warning)
                go.GetComponent<Text>().enabled = true;
        }
    }

    public static void DisplayTentWarning()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
        {
            /*if (go.name == "PremiE" || go.name == "PremiQ")
                go.GetComponent<Text>().enabled = false;*/
            if (go.name == "AvvisoTenda")
                go.GetComponent<Text>().enabled = true;
        }
    }

}
