using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    // An array of the maps waypoints
    private GameObject[] waypoints;

    // A list of all the Car objects
    private List<Car> allCars = new List<Car>();


	// Use this for initialization
	void Start ()
    {
        // Grab the waypoints that exist in the PlayerWaypoint script
        waypoints = GameObject.FindObjectOfType<PlayerWaypoint>().playerWaypoints;

        // Get all the PlayerCar objects and put them in the list
        GameObject[] temp = GameObject.FindGameObjectsWithTag("PlayerCar");
        foreach (GameObject c in temp)
        {
            allCars.Add(c.GetComponent<Car>());
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Calculate each car's distance along the race.
        foreach(Car car in allCars)
        {
            // Determine the previous waypoint
            int previousWaypoint = (car.nextWaypoint > 0) ? car.nextWaypoint - 1 : waypoints.Length - 1;

            // Calculate the distance vector from the previous waypoint
            Vector3 distanceFromPreviousWaypoint = (car.transform.position - waypoints[previousWaypoint].transform.position);

            // Calculate the distance vector between the previous and next waypoints
            Vector3 distanceBetweenLastandNextWaypoint = (waypoints[car.nextWaypoint].transform.position - waypoints[previousWaypoint].transform.position);

            // Calculate the fractional percentage of the path between waypoints that the car has travelled
            float fractionalDistance = Vector3.Dot(distanceFromPreviousWaypoint, distanceBetweenLastandNextWaypoint) / distanceBetweenLastandNextWaypoint.sqrMagnitude;

            // Calculate the total distance taking into account laps and waypoints and the fractional distance
            car.distance = car.currentLap * 100 + previousWaypoint * 10 + fractionalDistance;

            Vector3 directionFromPreviousWaypoint = distanceBetweenLastandNextWaypoint.normalized;
            Vector3 positionOnTrack = waypoints[previousWaypoint].transform.position;
            car.resetPosition = positionOnTrack;
            car.resetView = Quaternion.Euler(directionFromPreviousWaypoint);
        }

        // Sort the list of cars by their distance
        allCars.Sort(SortByPosition);

        // Update each car's position
        int t = 1;
        foreach(Car car in allCars)
        {
            car.position = t;
            t++;
        }
	}

    // Comparison method for sorting by distance
    static int SortByPosition(Car p1, Car p2)
    {
        return p2.distance.CompareTo(p1.distance);
    }
}
