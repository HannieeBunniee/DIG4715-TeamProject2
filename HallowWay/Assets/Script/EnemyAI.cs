using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent nav;

    public float patrolSpeed = 2.0f;

    public Transform[] waypoints1;
    private int curWaypoint1 = 0;
    private int maxWaypoint1;

    public Transform[] waypoints2;
    private int curWaypoint2 = 0;
    private int maxWaypoint2;

    private bool chasePlayer;
    private bool canHit;
    //public bool playerView;

    public float minWaypointDistance = 0.1f;

    public GameObject Player;


    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        chasePlayer = false;
        //playerView = false;
        canHit = true;

        maxWaypoint1 = waypoints1.Length - 1;
        maxWaypoint2 = waypoints2.Length - 1;
    }

    public void Update()
    {
        //chasing part with raycasthit

        


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            if (hit.collider.tag == "Player")
            {
                chasePlayer = true;
                //playerView = true;
            }
            else
            {
                //playerView = false;
            }

        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.red);


        if (chasePlayer == false)
        {
            PatrolMove();
        }
        if (chasePlayer == true)
        {
            ChaseMove();
            
        }


    }

    //===Functions===
    public void PatrolMove()
    {
        nav.speed = patrolSpeed;

        Vector3 tempLocalPosition;
        Vector3 tempWaypointPosition;

        tempLocalPosition = transform.position;
        tempLocalPosition.y = 0f;

        tempWaypointPosition = waypoints1[curWaypoint1].position;
        tempWaypointPosition.y = 0f;

        if (Vector3.Distance(tempLocalPosition, tempWaypointPosition) <= minWaypointDistance)
        {
            if (curWaypoint1 == maxWaypoint1)
                curWaypoint1 = 0;
            else
            {
                curWaypoint1++;
            }
        }
        nav.SetDestination(waypoints1[curWaypoint1].position);
    }

    public void ChaseMove()
    {
        nav.speed = patrolSpeed;

        Vector3 tempLocalPosition;
        Vector3 tempWaypointPosition;

        tempLocalPosition = transform.position;
        tempLocalPosition.y = 0f;

        tempWaypointPosition = waypoints2[curWaypoint2].position;
        tempWaypointPosition.y = 0f;

        if (Vector3.Distance(tempLocalPosition, tempWaypointPosition) <= minWaypointDistance)
        {
            if (curWaypoint2 == maxWaypoint2)
                curWaypoint2 = 0;
            else
            {
                curWaypoint2++;
            }
        }
        nav.SetDestination(waypoints2[curWaypoint2].position);
    }
}