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
                rb.MovePosition(new Vector2(trans.position.x + direction.x * moveSpeed, trans.position.y + direction.y * moveSpeed));
                //Debug.Log((waypoints[waypointIndex + 1].position - trans.position).magnitude);
                distanceToWaypoint = Vector3.Distance(trans.position, waypoints[waypointIndex + 1].position);
                RotateToWaypoint(direction);
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

        BoundaryCheck();


    }

    public void RotateToWaypoint(Vector3 _direction)
    {
        float offset = 180;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.left);
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));

    }

    public override void FishMovement()
    {

    }

    public override void initValues(Transform[] _waypoints)
    {
        base.initValues(_waypoints);
        waypoints = _waypoints;
    }
}
