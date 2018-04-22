using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour {
    public GameObject explosion_prefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
            Destroy(this.gameObject);
    }
    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 3f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.forward * 40 * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Instantiate(explosion_prefab, this.gameObject.transform.position, Quaternion.identity);
    }
}
