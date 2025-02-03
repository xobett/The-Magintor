using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] waypoints;

    private int waypointIndex;

    public float speed;

    void Start()
    {
        waypointIndex = 0;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypoints.Length > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 1f)
            {
                waypointIndex++;

                if (waypointIndex >= waypoints.Length)
                {
                    waypointIndex = 0;
                }
            } 
        }
        else if (waypoints == null) 
        {
            return;
        }
    }

}
