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

    //public List<Image> Flowers;
    public static bool DiarioON = false;
    public Transform sfondo;
    public Transform diario;

    public List<Sprite> Pages;
    public List<Sprite> pagesForNow;

    public Sprite white_left;

    Book scriptDiario;

    private void Start()
    {
        scriptDiario = diario.GetComponent<Book>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !InventoryUI.InventarioON && Interaction.PointingItem == null)
        {
            DiarioON = !DiarioON;
            sfondo.gameObject.SetActive(DiarioON);
            diario.gameObject.SetActive(DiarioON);

            /*if (scriptDiario.bookPages.Length % 2 == 0)
                scriptDiario.currentPage = scriptDiario.bookPages.Length;
            else
                scriptDiario.currentPage = scriptDiario.bookPages.Length + 1;*/

            Cursor.visible = DiarioON;

            if (DiarioON)
                Cursor.lockState = CursorLockMode.Confined;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
    }

    /*public bool Add(Item item)
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
    }*/

    public bool Add(Item item)
    {
        string sprite_name;
        string sprite_other;

        if (pagesForNow.Count % 2 == 0)
        {
            sprite_name = "_pari";
            sprite_other = "_dispari";
        }
        else
        {
            sprite_name = "_dispari";
            sprite_other = "_pari";
        }

        sprite_name = item.name + sprite_name;
        sprite_other = item.name + sprite_other;

        foreach (Sprite page in Pages)
        {
            if (page.name.Equals(sprite_name) && !pagesForNow.Contains(page))
            {
                foreach(Sprite sp in pagesForNow)
                {
                    if (sp.name.Equals(sprite_other))
                    {
                        return false;
                    }
                }
                //Debug.Log(page.name);
                pagesForNow.Add(page);
                Sprite[] temp;
                if (pagesForNow.Count % 2 != 0)
                {
                    temp = new Sprite[scriptDiario.bookPages.Length + 2];
                    temp[temp.Length - 1] = white_left;
                }
                else
                {
                    temp = new Sprite[scriptDiario.bookPages.Length];
                }

                pagesForNow.CopyTo(temp, 0);
                scriptDiario.bookPages = temp;

                //scriptDiario.bookPages[scriptDiario.bookPages.Length] = page;

                return true;
            }
        }

        return false;
    }

    public void ShowDiary()
    {
        if (!InventoryUI.InventarioON)
        {
            DiarioON = !DiarioON;
            sfondo.gameObject.SetActive(DiarioON);
            diario.gameObject.SetActive(DiarioON);

            Cursor.visible = DiarioON;

            if (DiarioON)
                Cursor.lockState = CursorLockMode.Confined;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
    }


}
