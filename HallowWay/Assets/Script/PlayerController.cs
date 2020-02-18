using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject loseScreen;

    //Start
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetPlayerHealth(maxHealth);
    }

    //Update
    private void Update()
    {
        if(currentHealth == 0)
        {
            Time.timeScale = 0f; //freeze the game
            Cursor.lockState = CursorLockMode.None; //unlock cursorLock so they can click buttons
            loseScreen.SetActive(true);
        }
    }
    //Colliders
    void OnTriggerEnter(Collider other) 
    {
        //since it on trigger, player CAN walk through it but it ok since it a ghost boss ;)
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(100);
        }
    }

   

    //======Functions======

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetPlayerHealth(currentHealth);
    }

}
