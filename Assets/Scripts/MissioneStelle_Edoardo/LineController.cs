using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour
{
    [SerializeField] List<Transform> dots;
    private LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = dots.Count;
    }
    // Update is called once per frame
    private void Update()
    {
       lr.SetPositions(dots.ConvertAll(d => d.position - new Vector3(0,0,5)).ToArray());
        
    }
}
