using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMouse : MonoBehaviour
{
    [SerializeField] private Image crosshair;

    public static bool isLaying = false;
    void Update()
    {
        if (Cursor.visible)
        {
            crosshair.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            isLaying = !isLaying;

            Cursor.visible = isLaying;

            if (isLaying)
                Cursor.lockState = CursorLockMode.Confined;
            else
                Cursor.lockState = CursorLockMode.Locked;

        }
    }
}
