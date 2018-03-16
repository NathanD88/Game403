using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // Set the waypoint number in the editor
    public int waypointNumber;

    private int totalWaypoints;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<Car>().CompareTag("PlayerCar"))
        {
            Car otherCar = other.GetComponentInParent<Car>();

            // If this is the start waypoint and the car's next waypoint is 0, increase lap
            if (waypointNumber == 0 && otherCar.nextWaypoint == 0)
            {
                otherCar.currentLap++;
            }

            // If the car's next waypoint is this waypoint, increment the next waypoint
            if (otherCar.nextWaypoint == waypointNumber)
            {
                otherCar.nextWaypoint++;
            }

            // If the nextwaypoint exceeds the total waypoints, set it back to 0
            if (otherCar.nextWaypoint == totalWaypoints)
            {
                otherCar.nextWaypoint = 0;
            }
            
        }
    }

    // Use this for initialization
    void Start ()
    {
        // Get the total waypoints from the length of the waypoints array in the PlayerWaypoint script
        totalWaypoints = GameObject.FindObjectOfType<PlayerWaypoint>().playerWaypoints.Length;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
