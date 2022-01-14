using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
   [SerializeField] private Image crosshair;

    public static Transform PointingItem = null;


    // Update is called once per frame
    void Update()
    {
        if(PointingItem != null)
            UnmarkSelectable();
        
        CheckAndMarkSelectable();
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
                foreach(GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                {
                    if (go.name == "PremiE")
                        go.GetComponent<Text>().enabled = true;
                    
                }
            }
            PointingItem = pointing;

        }
        
    }
    void UnmarkSelectable()
    {
        crosshair.GetComponent<Image>().color = Color.white;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
        {
            if (go.name == "PremiE")
                go.GetComponent<Text>().enabled = false;
        }
        PointingItem = null;
    }
}
