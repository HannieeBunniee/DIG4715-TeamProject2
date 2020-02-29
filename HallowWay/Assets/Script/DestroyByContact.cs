using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "EnemyBullet")
        {
            Destroy(collision.collider.gameObject);
            
        }

    }
}
