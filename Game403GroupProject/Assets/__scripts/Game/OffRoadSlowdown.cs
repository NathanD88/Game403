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
        if (other.transform.parent.gameObject.tag == "PlayerCar")
        {
            other.GetComponentInChildren<CarEngine>().offroad = true;
            Debug.Log("Off the Road");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.gameObject.tag == "PlayerCar")
        {
            other.GetComponentInChildren<CarEngine>().offroad = false;
            Debug.Log("back On Track");
        }
    }
}
