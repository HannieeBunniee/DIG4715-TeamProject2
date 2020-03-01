using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwingScript : MonoBehaviour
{
    private Animator n_animator;

    // Start is called before the first frame update
    void Start()
    {
        n_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            n_animator.SetTrigger("attack");
        }
    }
}
