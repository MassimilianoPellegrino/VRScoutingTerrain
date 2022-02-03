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
                crosshair.GetComponent<Image>().color = Color.red;
                if (!CallBonefire.LighterIsInHand())
                {
                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiE")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                else
                {
                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiQ")
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
            if (go.name == "PremiE" || go.name == "PremiQ" || go.name == "AvvisoFuoco")
                go.GetComponent<Text>().enabled = false;
        }
        PointingItem = null;
    }

    public static void DisplayBonfireWarning()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
        {
            if (go.name == "PremiE" || go.name == "PremiQ")
                go.GetComponent<Text>().enabled = false;
            if(go.name == "AvvisoFuoco")
                go.GetComponent<Text>().enabled = true;
        }
    }

}
