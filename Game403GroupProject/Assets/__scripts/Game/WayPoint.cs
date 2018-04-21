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

        if (other.transform.parent.CompareTag("PlayerCar"))
        {

            // If this is the start waypoint and the car's next waypoint is 0, increase lap
            if (waypointNumber == 0 && otherCar.nextWaypoint == 0)
            {
                if (!otherCar.isAI && otherCar.currentLap == 3)
                {
                    GameObject.FindObjectOfType<PlayerWaypoint>().EndRace();
                    otherCar.gameObject.GetComponent<RVP.BasicInput>().enabled = false;
                    GameObject.FindObjectOfType<GameController>().isGameOver = true;
                }
                else
                {
                    otherCar.currentLap++;
                }
            }

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

                    otherCar.resetPosition = this.transform.position;
                    otherCar.resetPosition.y = 31.6f;
                    otherCar.resetView = this.transform.rotation;
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
