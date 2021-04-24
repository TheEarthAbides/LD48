using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatedFish : EnemyFish
{

    private Transform[] waypoints;
    // Start is called before the first frame update
    private int waypointIndex = 0;
    public float moveSpeed = 0.1f;
    public float distanceToWaypoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex < waypoints.Length - 1)
        {
            if (trans.gameObject.activeInHierarchy && waypoints != null)
            {
                //direction to next waypoint
                Vector3 direction = (waypoints[waypointIndex + 1].position - waypoints[waypointIndex].position).normalized;
                Debug.Log(direction.x + " " + direction.y);
                rb.MovePosition(new Vector2(trans.position.x + direction.x * moveSpeed, trans.position.y + direction.y * moveSpeed));
                Debug.Log((waypoints[waypointIndex + 1].position - trans.position).magnitude);
                distanceToWaypoint = Vector3.Distance(trans.position, waypoints[waypointIndex + 1].position);

                if (distanceToWaypoint < 0.2f)
                {
                    waypointIndex++;
                }
            }
        }
        else
        {
            Die();
        }

        
    }

    public override void FishMovement()
    {

    }

    public override void initValues(Transform[] _waypoints)
    {
        
        waypoints = _waypoints;
    }
}
