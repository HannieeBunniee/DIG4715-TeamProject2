using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class econtroller : MonoBehaviour
{
    public GameObject ghost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyKill(bool enemyhit)
    {
        if (enemyhit == true)
        {
            StartCoroutine(StunTimer());
        }
       if (enemyhit == false)
       {
           Debug.Log("Hi hi");
        }
    }

    IEnumerator StunTimer()
    {
        ghost.SetActive(false);
        yield return new WaitForSeconds(3);
        ghost.SetActive(true);
    }
}
