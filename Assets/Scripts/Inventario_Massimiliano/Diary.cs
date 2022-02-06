using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    #region Singleton

    public static Diary instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Diary found!");
            return;
        }

        instance = this;
    }

    #endregion

    public List<Image> Flowers;
    public static bool DiarioON = false;
    public Transform diario;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !InventoryUI.InventarioON)
        {
            DiarioON = !DiarioON;
            diario.gameObject.SetActive(DiarioON);
        }
    }

    public bool Add(Item item)
    {
        foreach(Image image in Flowers)
        {            
            if (item.name.Equals(image.name) && !InventoryUI.InventarioON)
            {
                image.enabled = true;

                return true;
            }
        }

        return false;
    }


}
