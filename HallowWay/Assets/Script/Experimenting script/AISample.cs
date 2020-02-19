using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISample : MonoBehaviour
{
    public float patrolSpeed = 2.0f;

    private UnityEngine.AI.NavMeshAgent nav;

    public Transform[] waypoints1;
    private int curWaypoint1 = 0;
    private int maxWaypoint1;

    public Transform[] waypoints2;
    private int curWaypoint2 = 0;
    private int maxWaypoint2;

    public float minWaypointDistance = 0.1f;

    public GameObject Player;
    public float dist;

    public PlayerController playerController;
    public static bool playerHit;

    private bool chasePlayer;
    private bool itemAcquired;
    private bool canHit;
    public bool playerView;

    void Start()
    {
        chasePlayer = false;
        playerView = false;
        itemAcquired = false;
        canHit = true;

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        maxWaypoint1 = waypoints1.Length - 1;
        maxWaypoint2 = waypoints2.Length - 1;
    }
    public void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            if (hit.collider.tag == "Player")
            {
                chasePlayer = true;
                playerView = true;
            }
            else
            {
                playerView = false;
            }

        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.red);

        dist = Vector3.Distance(Player.transform.position, transform.position);

        if (chasePlayer == false)
        {
            PatrolMove();
        }
        else if (chasePlayer == true)
        {
            ChaseMove();
            CheckEnemy();
            EnemyDist();
        }
    }

    public void CheckEnemy()
    {
        if (itemAcquired == false)
        {
            StartCoroutine(ChaseTimer());
        }

        if (itemAcquired == true)
        {
            ChaseMove();
        }
    }

    public void EnemyConrtol(bool finalChase)
    {
        if (finalChase == true)
        {
            chasePlayer = true;
            itemAcquired = true;
        }
    }

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
    public void EnemyDist()
    {
        if (dist < 4 && canHit == true && playerView == true)
        {
            playerHit = true;
            //playerController.PlayHit(playerHit);
            StartCoroutine(StunTimer());
        }
    }

    IEnumerator ChaseTimer()
    {
        yield return new WaitForSeconds(10);
        chasePlayer = false;
    }

    IEnumerator StunTimer()
    {
        patrolSpeed = 0;
        canHit = false;
        yield return new WaitForSeconds(3);
        patrolSpeed = 2;
        canHit = true;
        playerHit = false;
        //playerController.PlayHit(playerHit);
    }
}