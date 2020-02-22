using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public GameObject swordOnHand;
    public PlayerCombat pCombatScript;
    public GameObject objectToDisable;

    private void Update()
    {
        transform.Rotate(new Vector3(45, 45, 45) * Time.deltaTime);
    }

    void OnTriggerEnter (Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Touched the Sword");
            objectToDisable.SetActive(false);
            swordOnHand.SetActive(true);
            gameObject.SetActive(false);
            pCombatScript.swordPickedUp = true;
        }
    }
}
