using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public GameObject swordOnHand;


    void OnTriggerEnter (Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Touched the Sword");
            swordOnHand.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
