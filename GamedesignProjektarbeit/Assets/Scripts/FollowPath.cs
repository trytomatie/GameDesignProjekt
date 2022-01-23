using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Transform[] waypoints;

    public int currentWaypoint;

    private StatusManager sm;
    // Start is called before the first frame update
    void Start()
    {
        sm = GetComponent <StatusManager> ();
        if(waypoints.Length == 0)
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Waypoint");
            waypoints = new Transform[gos.Length];
            for (int i = 0; i < gos.Length; i++)
            {
                waypoints[i] = gos[i].GetComponent<Transform>();
            }
               
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move ()
    {

        // Enemy can only move if the last Waypoint isn't reached
        if (currentWaypoint < waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, sm.moveSpeed * Time.deltaTime);

            // Once a Waypoint is reached, count goes up by 1 and Enemy starts moving towards the next Waypoint
            if (transform.position == waypoints[currentWaypoint].transform.position)
            {
                currentWaypoint = currentWaypoint + 1;
            }
        }
    }
}
