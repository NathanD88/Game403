using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour {
    public Transform path;
    public float maxSteerAngle = 180;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;

    private List<Transform> points = new List<Transform>();
    private int currentPoint = 0;
	// Use this for initialization
	void Start () {
        Transform[] pointTransform = path.GetComponentsInChildren<Transform>();
        Debug.Log(pointTransform.Length);
        points = new List<Transform>();
        for(int i = 0;i < pointTransform.Length; i++)
        {
            if (pointTransform[i] != path.transform)
            {
                points.Add(pointTransform[i]);
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        ApplySteer();
        Drive();
        CheckWayPointDistance();
	}

    private void CheckWayPointDistance()
    {
        if(Vector3.Distance(transform.position, points[currentPoint].position) < 5f)
        {
            if(currentPoint == points.Count - 1)
            {
                currentPoint = 0;
                Debug.Log(points[currentPoint].name);
            }
            else
            {
                currentPoint++;
                Debug.Log(points[currentPoint].name);
            }
        }
        else
        {
            Debug.Log(points[currentPoint].name);
        }
    }
    private void Drive()
    {
        wheelFL.motorTorque = 120;
        wheelFR.motorTorque = 120;
        
    }
    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(points[currentPoint].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }
}
