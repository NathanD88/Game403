using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // Rigidbody mrb = GetComponent<Rigidbody>();
        //mrb.AddForce( * 1000);
        //this.gameObject.transform.Translate(Vector3.forward * 10);
        Destroy(this.gameObject, 3f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.forward * 40 * Time.deltaTime);
    }
}
