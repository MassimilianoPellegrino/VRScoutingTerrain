using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLine : MonoBehaviour
{
    public LineRenderer liner;
    public Transform pos1;
    public Transform pos2;

    // Start is called before the first frame update
    void Start()
    {
        liner.positionCount = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        liner.SetPosition(0,pos1.position);
        liner.SetPosition(1,pos2.position);
    }
}
