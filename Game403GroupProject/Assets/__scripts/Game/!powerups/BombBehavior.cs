using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour {
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
	void Update () {
		
	}
    private void OnDestroy()
    {
        Instantiate(explosion_prefab, this.gameObject.transform.position, Quaternion.identity);
    }
}
