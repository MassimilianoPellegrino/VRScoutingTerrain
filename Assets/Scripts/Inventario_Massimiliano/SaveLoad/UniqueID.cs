using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueID : MonoBehaviour
{
    public string ID { get; set; }

    private void Awake()
    {
        ID = transform.position.sqrMagnitude + "-" + name + "-" + transform.GetSiblingIndex();
        Debug.Log("ID for " + name + "is" + ID);
    }
}
