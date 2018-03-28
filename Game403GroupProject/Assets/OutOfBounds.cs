﻿using System.Collections;
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
        if (thisCar = other.GetComponentInParent<Car>())
        {
            thisCar.GetComponent<Rigidbody>().velocity = Vector3.zero;
            thisCar.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            thisCar.transform.rotation = Quaternion.Euler(Vector3.zero);
            thisCar.transform.position = thisCar.resetPosition;
            thisCar.GetComponent<Rigidbody>().rotation = thisCar.resetView;
            
        }
    }
}
