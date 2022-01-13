using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    private bool carrying = false;

    private void Update()
    {
        if (SelectionManager._selection != null)
        {
            Transform selected = SelectionManager._selection;

            if (Input.GetKeyDown(KeyCode.E) && !selected.CompareTag("Terrain"))
            {

                if (carrying == true)
                {
                    selected.parent = null;
                    //selected.GetComponent<Rigidbody>().freezeRotation = false;
                    //selected.GetComponent<Rigidbody>().useGravity = true;
                    selected.GetComponent<Rigidbody>().isKinematic = false;
                    carrying = false;
                }
                else
                {
                    selected.GetComponent<Rigidbody>().isKinematic = true;
                    //selected.GetComponent<Rigidbody>().useGravity = false;
                    //selected.GetComponent<Rigidbody>().freezeRotation = true;
                    selected.position = theDest.position;
                    selected.parent = theDest;
                    carrying = true;
                  
                }
            }
        }

        
    }
    
}
