using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // Set the waypoint number in the editor
    public int waypointNumber;

    PlayerWaypoint activeWaypoint;
    private int totalWaypoints;

    private void OnTriggerEnter(Collider other)
    {
        Car otherCar = other.GetComponentInParent<Car>();

        if (other.GetComponentInParent<Car>().CompareTag("PlayerCar"))
        {

            // If this is the start waypoint and the car's next waypoint is 0, increase lap
            if (waypointNumber == 0 && otherCar.nextWaypoint == 0)
            {
                otherCar.currentLap++;
            }

            //// If the nextwaypoint exceeds the total waypoints, set it back to 0
            //if (otherCar.nextWaypoint == totalWaypoints)
            //{
            //    otherCar.nextWaypoint = 0;
            //}

            // If the car's next waypoint is this waypoint, increment the next waypoint
            if (otherCar.nextWaypoint == waypointNumber)
            {
                otherCar.nextWaypoint++;

                // If the nextwaypoint exceeds the total waypoints, set it back to 0
                if (otherCar.nextWaypoint == totalWaypoints)
                {
                    otherCar.nextWaypoint = 0;
                }

                if (!otherCar.GetComponentInParent<RVP.FollowAI>().isActiveAndEnabled)
                {
                    if (waypointNumber == totalWaypoints - 1)
                    {
                        activeWaypoint.playerWaypoints[0].GetComponent<MeshRenderer>().enabled = true;
                    }
                    else
                    {
                        activeWaypoint.playerWaypoints[waypointNumber + 1].GetComponent<MeshRenderer>().enabled = true;
                    }

                    activeWaypoint.playerWaypoints[waypointNumber].GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        // Get the total waypoints from the length of the waypoints array in the PlayerWaypoint script
        totalWaypoints = GameObject.FindObjectOfType<PlayerWaypoint>().playerWaypoints.Length;

        activeWaypoint = GameObject.FindObjectOfType<PlayerWaypoint>();
    }
}
