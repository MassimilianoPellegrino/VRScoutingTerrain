using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR : MonoBehaviour
{
    public LineRenderer mLinea;
    // Start is called before the first frame update
    void Start()
    {
        mLinea = GetComponent<LineRenderer>();
        mLinea.alignment = LineAlignment.View;
        mLinea.endColor = Color.yellow;
        mLinea.startColor = Color.white;
        mLinea.loop = false;
        mLinea.numCapVertices = 10;
        mLinea.numCornerVertices = 10;
        mLinea.useWorldSpace = true;
        mLinea.startWidth = 0.1f;
        mLinea.Simplify(5);
        mLinea.positionCount++;
        mLinea.SetPosition(2, new Vector3(0,0,5f));
        Vector3 miPosition = mLinea.GetPosition(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
