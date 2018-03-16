using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {
    public float maxSteerAngle = 40f;
    public float maxAccel = 120f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Accelerate();
        Steer();
    }
    void Accelerate()
    {
        float accel = Input.GetAxis("Vertical") * maxAccel;
        wheelFL.motorTorque = accel;
        wheelFR.motorTorque = accel;
    }
    void Steer()
    {
        float kurtAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
        wheelFL.steerAngle = kurtAngle;
        wheelFR.steerAngle = kurtAngle;
    }
}
