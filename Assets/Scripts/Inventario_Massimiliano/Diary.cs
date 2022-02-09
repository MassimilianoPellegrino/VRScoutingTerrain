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

    public static bool DiarioON = false;
    public Transform sfondo;
    public Transform diario;

    public List<Sprite> Pages;
    public List<Sprite> pagesForNow;

    public Sprite white_left;

    MyBook scriptDiario;

    private void Start()
    {
        scriptDiario = diario.GetComponent<MyBook>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !InventoryUI.InventarioON && (Interaction.PointingItem == null || ShowMouse.isLaying))
        {
            scriptDiario.UpdateSprites();

            DiarioON = !DiarioON;
            sfondo.gameObject.SetActive(DiarioON);
            diario.gameObject.SetActive(DiarioON);

            if (!ShowMouse.isLaying)
            {
                Cursor.visible = DiarioON;

                if (DiarioON)
                    Cursor.lockState = CursorLockMode.Confined;
                else
                    Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public bool Add(Item item)
    {
        string sprite_name;
        string sprite_other;

        if (scriptDiario.bookPages.Count % 2 == 0)
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
            if (page.name.Equals(sprite_name) && !scriptDiario.bookPages.Contains(page))
            {
                foreach (Sprite sp in scriptDiario.bookPages)
                {
                    if (sp.name.Equals(sprite_other))
                    {
                        return false;
                    }
                }

                pagesForNow.Add(page);

                
                if (pagesForNow.Count%2 != 0)
                {
                    scriptDiario.bookPages.Add(page);
                    scriptDiario.bookPages.Add(white_left);
                }
                else
                {
                    scriptDiario.bookPages[scriptDiario.bookPages.Count - 1] = page;
                }


                return true;
            }
        }

        return false;
    }

    public void ShowDiary()
    {
        scriptDiario.UpdateSprites();

        if (!InventoryUI.InventarioON)
        {
            DiarioON = !DiarioON;
            sfondo.gameObject.SetActive(DiarioON);
            diario.gameObject.SetActive(DiarioON);

            if (!ShowMouse.isLaying)
            {
                Cursor.visible = DiarioON;

                if (DiarioON)
                    Cursor.lockState = CursorLockMode.Confined;
                else
                    Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void GiveMedal(Item medal)
    {

    }


}
