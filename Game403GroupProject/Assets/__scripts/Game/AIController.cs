using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Car), typeof(CarEngine))]
public class AIController : MonoBehaviour
{

    private GameObject[] waypoints;
    private Car thisCar;
    private RVP.DriveForce thisCarDrive;


    private NavMeshAgent agent;
	// Use this for initialization
	void Start ()
    {
        // Grab the waypoints that exist in the PlayerWaypoint script
        waypoints = GameObject.FindObjectOfType<PlayerWaypoint>().playerWaypoints;

        // Grab the car components
        thisCar = GetComponent<Car>();
        thisCarDrive = GetComponent<RVP.DriveForce>();

        //agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //thisCarDrive.
        GameObject waypoint = GameObject.Find("WayPoint");
        agent.SetDestination(waypoint.transform.position);
	}
}
