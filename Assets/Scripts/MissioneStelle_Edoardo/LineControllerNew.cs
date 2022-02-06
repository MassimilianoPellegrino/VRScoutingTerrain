using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControllerNew : MonoBehaviour
{
    private LineRenderer lr;
    private List<DotsController> dots;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;

        dots = new List<DotsController>();
    }

    public void AddPoint(DotsController dot)
    {
        dot.index = dots.Count;
        dot.SetLine(this);

        lr.positionCount++;
        dots.Add(dot);
    }

    public void SplitPointAsAtIndex(int index, out List<DotsController> beforeDots, out List<DotsController> AfterDots)
    {
        List<DotsController> before = new List<DotsController>();
        List<DotsController> after = new List<DotsController>();

        int i = 0;
        for(; i < index; i++)
        {
            before.Add(dots[i]);
        }
        i++;

           for(; i < dots.Count; i++)
        {
            after.Add(dots[i]);
        }

        beforeDots = before;
        AfterDots = after;
    }


    private void LateUpdate()
    {
        if(dots.Count >= 2)
        {
            for(int i = 0; i < dots.Count; i++)
            {
                lr.SetPosition(i, dots[i].transform.position);
            }
        }
    }
}
