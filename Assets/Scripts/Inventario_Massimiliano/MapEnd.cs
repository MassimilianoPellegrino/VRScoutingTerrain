using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapEnd : MonoBehaviour
{
    Text MapEndWarning;

    public static bool endReached;

    private void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Indicazione"))
        {
            if (go.name == "AvvisoConfini")
            {
                MapEndWarning = go.GetComponent<Text>();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endReached = true;
            MapEndWarning.enabled = true;
            Invoke(nameof(ClearScreen), 2);
        }
    }

    void ClearScreen()
    {
        MapEndWarning.enabled = false;
        endReached = false;
    }
}
