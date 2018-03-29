using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerCar"))
        {
            Debug.Log(other.gameObject);
            GameObject targetPlayer = other.gameObject;
            GameObject.FindObjectOfType<GameController>().GenerateRandomPowerup(targetPlayer);
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime, Space.World);
	}
}
