using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectCamera : MonoBehaviour {

	public float moveCam;

	public float smooth;
	// Use this for initialization
	void Update () {
		
		if (Input.GetButtonDown("CamMove"))
		{
			//transform.position = Vector3.Lerp (transform.position, target.position, Time.deltaTime * smooth);
		}
			
	}
}
