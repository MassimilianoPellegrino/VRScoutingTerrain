using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenTool : MonoBehaviour
{
    [Header("Pen Canvas")]
    [SerializeField] private PenCanvas penCanvas;
    
    [Header("Dots")]
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] Transform dotParent;
    
    [Header("Lines")]
    [SerializeField] Transform lineParent;
    [SerializeField] private GameObject linePrefab;
    
    private LineControllerNew currentLine;

    private void Start()
    { 
        penCanvas.OnPenCanvasLeftClickEvent += AddDot;
        penCanvas.OnPenCanvasRightClickEvent += EndCurrentLine;
    }


    private void EndCurrentLine()
    {
        if(currentLine != null)
        {
            currentLine = null;     
        }
    }



    private void AddDot()
    {
        if(currentLine == null)
            {
                currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineControllerNew>();

            }

        DotsController dot = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent).GetComponent<DotsController>();
        dot.OnDragEvent += MoveDot;
        dot.OnRightCLickEvent += RemoveDot;
       
        currentLine.AddPoint(dot);
    }

   

    private void MoveDot(DotsController dot)
    {
        dot.transform.position = GetMousePosition();
    }

      private void RemoveDot(DotsController dot)
    {
        LineControllerNew line = dot.line;
        line.SplitPointAsAtIndex(dot.index, out List<DotsController> before, out List<DotsController> after);

        Destroy(line.gameObject);
        Destroy(dot.gameObject);


        LineControllerNew beforeLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineControllerNew>();
           for(int i = 0; i < before.Count; i++)
        {
            beforeLine.AddPoint(before[i]);
        }

         LineControllerNew afterLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineControllerNew>();
           for(int i = 0; i < after.Count; i++)
        {
            afterLine.AddPoint(after[i]);
        }

    }

    private Vector3 GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
   
}
