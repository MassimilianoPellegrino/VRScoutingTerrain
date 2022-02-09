using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
   [SerializeField] private Image crosshair;

    public static Transform PointingItem = null;
    private bool isPointing = false;

    Transform PointingNPC = null;

    public static Item item = null;

    // Update is called once per frame
    void Update()
    {

        crosshair.enabled = !ShowMouse.isLaying;

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

            if (pointing.CompareTag("Selectable") && pointing.GetComponent<ItemPickup>()!= null && !Diary.DiarioON && !InventoryUI.InventarioON)
            {

                item = pointing.GetComponent<ItemPickup>().item;

                crosshair.GetComponent<Image>().color = Color.red;

                if (item.isFlower)
                {
                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiF_fiore")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                else if (!CallBonefire.LighterIsInHand() && !CallTent.RopeIsInHand())
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
            else if(pointing.CompareTag("NPC") /*&& pointing.GetComponent<InteractableNPC>() != null*/ && !Diary.DiarioON && !InventoryUI.InventarioON)
            {
                crosshair.GetComponent<Image>().color = Color.red;
                PointingNPC = pointing;
                isPointing = true;

                PointingNPC.GetComponent<MyNPC>().Interact();

                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                {
                    if (go.name == "PremiE_npc")
                        go.GetComponent<Text>().enabled = true;

                }
            }
            else
            {
                PointingItem = null;
                PointingNPC = null;
                isPointing = false;
            }

        }
        else if (Physics.Raycast(ray, out hit))
        {
            Transform pointing = hit.transform;
            

            if (pointing.CompareTag("Constellation") && pointing.GetComponent<ItemPickup>() != null && !Diary.DiarioON && !InventoryUI.InventarioON && ShowMouse.isLaying)
            {

                item = pointing.GetComponent<ItemPickup>().item;

                crosshair.GetComponent<Image>().color = Color.red;

                if (item.isConstellation)
                {
                    
                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "Click_costellazione")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                PointingItem = pointing;
                isPointing = true;
            }
            else
            {
                PointingNPC = null;
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
        if (PointingItem == null && PointingNPC == null)
        {
            crosshair.GetComponent<Image>().color = Color.white;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
            {
                go.GetComponent<Text>().enabled = false;
            }
            PointingItem = null;
            PointingNPC = null;
        }
    }

    public static void DisplayWarning(string warning)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
        {
            if(go.name == warning)
                go.GetComponent<Text>().enabled = true;
        }
    }

    public static void DisplayTentWarning()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
        {
            if (go.name == "AvvisoTenda")
                go.GetComponent<Text>().enabled = true;
        }
    }

}
