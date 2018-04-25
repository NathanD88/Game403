using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffRoadSlowdown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.gameObject.CompareTag("PlayerCar"))
        {
            other.transform.parent.GetComponent<Rigidbody>().drag = 0.5f; 
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.gameObject.CompareTag("PlayerCar"))
        {
            other.transform.parent.GetComponent<Rigidbody>().drag = 0.01f;
        }
    }
}
