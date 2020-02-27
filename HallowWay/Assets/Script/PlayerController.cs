﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject loseScreen;

    public GameController gameController;


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
            //Time.timeScale = 0f; //freeze the game //THIS FREEZE THE GAME BUT WONT UNFREEZE IT WHEN PRESSED RESTART
            Cursor.lockState = CursorLockMode.None; //unlock cursorLock so they can click buttons
            gameController.LoseAudio();
            //gameController.lost = true;
            loseScreen.SetActive(true);

        }
    }
    //Colliders
    void OnTriggerEnter(Collider other) 
    {
        //since it on trigger, player CAN walk through it but it ok since it a ghost boss ;)
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(20);
        }

    }


   

    //======Functions======

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetPlayerHealth(currentHealth);
    }

}
