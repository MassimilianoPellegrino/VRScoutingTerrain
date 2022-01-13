using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
   [SerializeField] private Image crosshair;

    public static Transform _selection = null;


    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            crosshair.GetComponent<Image>().color = Color.white;
            _selection = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit) && hit.distance<=5f)
        {
            Transform selection = hit.transform;
            if (selection.CompareTag("Selectable"))
            {
                crosshair.GetComponent<Image>().color = Color.red;
            }
            _selection = selection;

        }
    }
}
