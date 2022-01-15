using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI1 : MonoBehaviour
{
    bool InventarioON = false;
    Transform inventario;

    private Inventory1 inventory;
    private Transform itemsSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        //itemSlotContainer = transform.Find("itemSlotContainer");
    }

    public void SetInventory(Inventory1 inventory)
    {
        this.inventory = inventory;
    }

    void Start()
    {
        Cursor.visible = InventarioON;
        Cursor.lockState = CursorLockMode.Locked;
        inventario = gameObject.transform.Find("Inventario");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventarioON = !InventarioON;
            inventario.gameObject.SetActive(InventarioON);
            Cursor.visible = InventarioON;

            if (InventarioON)
                Cursor.lockState = CursorLockMode.Confined;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }


    }

}
