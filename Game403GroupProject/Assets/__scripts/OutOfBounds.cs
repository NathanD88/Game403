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

    private void OnTriggerEnter(Collider other)
    {
        Car thisCar;
        if (other.transform.parent.CompareTag("PlayerCar") && (thisCar = other.GetComponentInParent<Car>()))
        {
            ResetCar(thisCar);
            //thisCar.GetComponent<Rigidbody>().rotation = thisCar.resetView;
            
        }
    }

    public void ResetCar(Car c)
    {
        c.GetComponent<Rigidbody>().velocity = Vector3.zero;
        c.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        c.transform.rotation = c.resetView;
        c.transform.position = c.resetPosition;
    }
}
