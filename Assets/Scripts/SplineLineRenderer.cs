using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineLineRenderer : MonoBehaviour
{
    //HIGH QUALITY CODE UP AHEAD
    public SplineContainer spline;

    public bool isDOOM;

    [ContextMenu("Generate")]
    void GenerateLine()
    {


        var line = GetComponent<LineRenderer>();
        List<Vector3> points = new List<Vector3>();
        line.positionCount = 100;
        for (float i = 0; i <= 1; i += 0.01f)
        {
            points.Add(spline.Splines[0].EvaluatePosition(i));
        }

        line.SetPositions(points.ToArray());
        line.Simplify(0.01f);

    }

    void Start()
    {

    }

    void Update()
    {

        if (isDOOM)
        {

            if (CPU.health >= 500)
            {
                GetComponent<LineRenderer>().positionCount = 0;
            }
            else
            {

                var line = GetComponent<LineRenderer>();
                List<Vector3> points = new List<Vector3>();
                
                for (float i = 0; i <= (500 - CPU.health) / 500; i += 0.01f)
                {
                    points.Add(spline.Splines[0].EvaluatePosition(i));
                }
                line.positionCount = points.Count;
                line.SetPositions(points.ToArray());
                line.Simplify(0.01f);
            }


        }

    }
}
