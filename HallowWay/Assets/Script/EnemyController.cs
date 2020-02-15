using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play hurt animation if any
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        //play die animation if any --animator.SetBool("name",true/false)
        //this code make to disable enemy script along with  it collider so it player wont walk over
        //Help alot when enemy is dead on the floor
        /*GetComponent<Collider>().enabled = false;
         this.enabled = false;*/
        Destroy(gameObject);
    }
}
