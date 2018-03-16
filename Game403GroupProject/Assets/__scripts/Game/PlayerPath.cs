using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPath : MonoBehaviour
{
    public Color linecolor2;

    private List<Transform> points = new List<Transform>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = linecolor2;

        Transform[] pointTransform = GetComponentsInChildren<Transform>();
        points = new List<Transform>();
        foreach (Transform t in pointTransform)
        {
            if (t != transform)
            {
                points.Add(t);
            }
        }

        for (int i = 0; i < points.Count; i++)
        {
            Vector3 current = points[i].position;
            Vector3 previous = Vector3.zero;
            if (i > 0)
            {
                previous = points[i - 1].position;
            }
            else if (i == 0 && points.Count > 1)
            {
                previous = points[points.Count - 1].position;
            }
            Gizmos.DrawLine(previous, current);
            Gizmos.DrawWireSphere(current, 1f);
        }


    }
}
