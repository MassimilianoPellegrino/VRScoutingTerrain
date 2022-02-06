using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lr;
    private Vector2 mousePos;
    private Vector3 startMousePos;

    
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

         if(Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
            lr.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));

        }
        
    }
}
