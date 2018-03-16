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
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerCar")
        {
            other.GetComponent<VehicleAssist>().offroad = true;
            Debug.Log("Off the Road");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerCar")
        {
            other.GetComponent<"VehicleAssist">().offroad = false;
            Debug.Log("back On Track");
        }
    }
}
