using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EC : MonoBehaviour {
    
    //creates spot range variable for you to muck around with in the inspector
    public float ChaseRange;
    //public float StopRange;
    //creates a place for the navmesh component added via scene editor and the inspector. 
    private NavMeshAgent agent;
    
    //Call the enemy patrol script.
    private EP EP;

    //looking for the script in gameobbject to enable
    public GameObject scriptEnable;

    //creates a target slot in the inspector
    public Transform target;

    // Use this for initialization
    void Start ()
    {
        //scriptEnable.SetActive(true);
        scriptEnable.GetComponent<WeaponController>().enabled = false;

        //retrieves the navmesh agent component and assigns it to the space we made earlier
        agent = GetComponent<NavMeshAgent>();
        
        //Check for the enemy patrol script. Returns null if one isn't attached.
        EP = GetComponent<EP>();

    }        


	
	// Update is called once per frame
	void Update() {
        //get distance from self and target
        float distance = Vector3.Distance(target.position, transform.position);

        //check if the distance is within chaserange, and outside of stoprange // && (distance >= StopRange)
        if ((distance <= ChaseRange))
        {
            //scriptEnable.SetActive(true);
            scriptEnable.GetComponent<WeaponController>().enabled = true;
            //make the navmesh agent's goal the player's current position. 
            agent.destination = target.position;
        }
        //stop the navmesh agent from moving when too close or too far away. This also checks for an Enemy Patrol script, so the two don't clash.
        if (distance >= ChaseRange)
        {
             if (EP == null) {
            agent.destination = transform.position;
             }
             else {
        }
        }
        /*if (distance <= StopRange)
        {
            agent.destination = transform.position;
        }*/

    }
}