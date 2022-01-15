using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    bool InventarioON = false;
    Transform inventario;


    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;

    public Text SpawnInstruction;

    void Start()
    {
        Cursor.visible = InventarioON;
        Cursor.lockState = CursorLockMode.Locked;
        inventario = gameObject.transform.Find("Inventario");

        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(true);
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

    void UpdateUI()
    {
        if (inventory.items.Count > 0)
        {
            SpawnInstruction.GetComponent<Text>().enabled = true;
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

        if (inventory.items.Count == 0)
        {
            SpawnInstruction.GetComponent<Text>().enabled = false;
        }
    }
}
