using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private int attackDamage = 20;

    public AudioSource musicSource;
	public float attackRate = 2f;
    float nextAttackTime = 0f;
    public bool swordPickedUp;

    public GameObject ghost;
    //public GameObject scriptEnable;

    private void Start()
    {
        swordPickedUp = false;
    }

    private void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButton(0) && swordPickedUp == true)
            {
                Debug.Log("attack pressed");
                Attack();
                nextAttackTime = Time.time + 1f / attackRate; //cool down time in hitting attack again
				GetComponent<AudioSource>().Play ();
            }
        }

        /*if (Input.GetMouseButton(0))
        {
            Debug.Log("attack pressed");
            Attack();
        }*/
    }

    void Attack()
    {
        //Play Attack Animation

        //Decting Enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("Enemy hit");
            //enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
            killenemy();
        }
    }

    public void killenemy()
    {
        StartCoroutine(StunTimer());
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator StunTimer()
    {
        //scriptEnable.GetComponent<WeaponController>().enabled = false;
        ghost.SetActive(false);
        yield return new WaitForSeconds(3);
        ghost.SetActive(true);
        //scriptEnable.GetComponent<WeaponController>().enabled = true;
    }
}
