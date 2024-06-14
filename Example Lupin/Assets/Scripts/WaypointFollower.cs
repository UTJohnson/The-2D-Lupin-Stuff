using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * WaypointFollower is a script for Unity that enables an object to follow a series of waypoints.
 * 
 * Variables:
 * - waypoints: An array of GameObjects representing the waypoints that the object will follow.
 * - currentWaypointIndex: An integer tracking the current waypoint the object is moving towards.
 * - speed: A float determining the speed at which the object moves towards the waypoint.
 * 
 * Methods:
 * - Update: Called once per frame, this method moves the object towards the current waypoint. 
 *   When the object is close enough to the current waypoint (within 0.1 units), it increments the waypoint index.
 *   If the index exceeds the length of the waypoints array, it loops back to the start.
 *   The object then moves towards the new current waypoint.
 */


public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;

    void Update()
    {

        if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        { 
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
