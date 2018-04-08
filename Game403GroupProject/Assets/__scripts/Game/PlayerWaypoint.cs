using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaypoint : MonoBehaviour
{
    public GameObject[] playerWaypoints;

    int counter = 0;
    public float distance = 20.0f;

    Vector3 direction;
    public GameObject car;
    private HUDController hudController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCar"))
        {
            this.gameObject.SetActive(false);
        }
    }

    // Use this for initialization
    void Start ()
    {
        hudController = GameObject.FindObjectOfType<HUDController>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        direction = Vector3.zero;
        Vector3 wayPointPosition = playerWaypoints[counter].transform.position;
        wayPointPosition.y = 0;

        Vector3 playerPosition = car.transform.position;
        playerPosition.y = 0;

        direction = wayPointPosition - playerPosition;

        if(direction.magnitude < distance)
        {
            if(counter < playerWaypoints.Length-1)
            {
                counter++;
                //Debug.Log("Go To Next Checkpoint");
            }
            else
            {
                counter = 0;
            }
        }
    }
}

