using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Reset the car to previous waypoint if out of bounds
    private void OnTriggerEnter(Collider other)
    {
        Car thisCar = other.GetComponent<Car>();
        if (other.CompareTag("PlayerCar") && (thisCar != null))
        {
            ResetCar(thisCar);            
        }
    }

    // Reset car's position, rotation, velocity, and angular velocity to previous waypoint
    public void ResetCar(Car c)
    {
        c.GetComponent<Rigidbody>().velocity = Vector3.zero;
        c.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        c.transform.rotation = c.resetView;
        c.transform.position = c.resetPosition;
    }
}
