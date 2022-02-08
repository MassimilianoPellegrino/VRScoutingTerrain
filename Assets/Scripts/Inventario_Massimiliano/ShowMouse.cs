using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMouse : MonoBehaviour
{
    public static bool isLaying = false;
    void Update()
    {
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
