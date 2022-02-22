using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
   [SerializeField] private Image crosshair;

    public static Transform PointingItem = null;
    private bool isPointing = false;

    public static Transform PointingNPC = null;

    public static Item item = null;

    public float PickUpDistance;

    public List<Text> indicazioni;

    Transform lastPointed;

    // Update is called once per frame

    private void Start()
    {
        /*foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
        {
            indicazioni.Add(go.GetComponent<Text>());
        }*/
    }

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
        if (Physics.Raycast(ray, out hit, PickUpDistance))
        {

            Transform pointing = hit.transform;

            if (pointing.CompareTag("Selectable") && pointing.GetComponent<ItemPickup>()!= null && !InventoryUI.InventarioON)
            {
                if (lastPointed != null)
                {
                    if (!lastPointed.gameObject.Equals(pointing.gameObject))
                    {
                        lastPointed.GetComponentInChildren<Outline>().enabled = false;
                        lastPointed = null;
                    }
                }

                item = pointing.GetComponent<ItemPickup>().item;

                crosshair.GetComponent<Image>().color = Color.red;

                pointing.GetComponentInChildren<Outline>().enabled = true;

                lastPointed = pointing;

                if (item.isFlower && GetComponent<FlowersQuest>().enabled)
                {
                    foreach (Text ind in indicazioni)
                        ind.enabled = false;

                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiF_fiore")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                else if (!HandsOccupied.handsOccupied && !item.isFlower)
                {
                    foreach (Text ind in indicazioni)
                        ind.enabled = false;

                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiE")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                else if(CallBonefire.LighterIsInHand() && item.neededForBonfire && GetComponent<FireQuest>().enabled)
                {
                    foreach (Text ind in indicazioni)
                        ind.enabled = false;

                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiQ_fuoco")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                else if (CallTent.RopeIsInHand() && item.neededForTent && GetComponent<TentQuest>().enabled)
                {
                    foreach (Text ind in indicazioni)
                        ind.enabled = false;

                    foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                    {
                        if (go.name == "PremiQ_tenda")
                            go.GetComponent<Text>().enabled = true;

                    }
                }
                PointingItem = pointing;
                isPointing = true;
            }
            else if(pointing.CompareTag("NPC") && !Diary.DiarioON && !InventoryUI.InventarioON)
            {
                crosshair.GetComponent<Image>().color = Color.red;
                PointingNPC = pointing;
                isPointing = true;

                foreach (Text ind in indicazioni)
                    ind.enabled = false;

                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
                {
                    if (go.name == "PremiE_npc" && !MyDialogueSystem.dialogueON)
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
                if (lastPointed != null)
                {
                    if (!lastPointed.gameObject.Equals(pointing.gameObject))
                    {
                        lastPointed.GetComponentInChildren<Outline>().enabled = false;
                        lastPointed = null;
                    }
                }


                item = pointing.GetComponent<ItemPickup>().item;

                crosshair.GetComponent<Image>().color = Color.red;

                pointing.GetComponentInChildren<Outline>().enabled = true;

                lastPointed = pointing;

                if (item.isConstellation && GetComponent<StarsQuest>().enabled)
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
        if (PointingItem == null && PointingNPC == null && !MapEnd.endReached)
        {
            crosshair.GetComponent<Image>().color = Color.white;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
            {
                go.GetComponent<Text>().enabled = false;
            }
            PointingItem = null;
            PointingNPC = null;

            if(lastPointed != null)
            {
                lastPointed.GetComponentInChildren<Outline>().enabled = false;
                lastPointed = null;
            }
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
