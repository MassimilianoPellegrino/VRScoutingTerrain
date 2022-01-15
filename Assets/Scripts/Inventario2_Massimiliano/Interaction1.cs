using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction1 : MonoBehaviour
{
    [SerializeField] private Image crosshair;

    public static Transform PointingItem = null;
    private bool isPointing = false;

    private Inventory1 inventory;
    [SerializeField] private InventoryUI1 uiInventory;


    // Update is called once per frame

    private void Awake()
    {
        inventory = new Inventory1();
        uiInventory.SetInventory(inventory);
    }

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
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                {
                    if (go.name == "PremiE")
                        go.GetComponent<Text>().enabled = true;

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
            if (go.name == "PremiE")
                go.GetComponent<Text>().enabled = false;
        }
        PointingItem = null;
    }
}
