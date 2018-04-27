using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerCar"))
        {
            GameObject targetPlayer = other.gameObject;
            GameObject.FindObjectOfType<PowerupManager>().RandomPickupPlayer(targetPlayer);
            StartCoroutine(DisablePickup(5));
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime, Space.World);
	}

    private IEnumerator DisablePickup(float delay)
    {
        Renderer rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
        Collider col = GetComponent<BoxCollider>();
        col.enabled = false;
        yield return new WaitForSeconds(5);

        rend.enabled = true;
        col.enabled = true;
    }
}
