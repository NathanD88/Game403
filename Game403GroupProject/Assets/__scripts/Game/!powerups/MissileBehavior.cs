using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour {
    public GameObject explosion_prefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerCar"))
            Destroy(this.gameObject);
    }
    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 3f);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(Vector3.forward * 40 * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (1.0f - hit.distance), transform.position.z);
        }
    }

    private void OnDestroy()
    {
        Instantiate(explosion_prefab, this.gameObject.transform.position, Quaternion.identity);
    }
}
