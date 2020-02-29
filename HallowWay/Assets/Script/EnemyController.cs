using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Slider healthBar;
    public GameObject objectToDisable;
    public GameObject objectToDisable2;
    //public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetBossHealth(maxHealth);
    }

    private void Update()
    {
        healthBar.value = currentHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //healthBar.SetBossHealth(maxHealth);
        //play hurt animation if any
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        objectToDisable.SetActive(false);
        objectToDisable2.SetActive(false);
        //play die animation if any --animator.SetBool("name",true/false)
        //this code make to disable enemy script along with  it collider so it player wont walk over
        //Help alot when enemy is dead on the floor
        /*GetComponent<Collider>().enabled = false;
         this.enabled = false;*/
        Destroy(gameObject);
    }
}
