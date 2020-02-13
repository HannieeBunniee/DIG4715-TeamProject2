using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to use UI text

public class GameControllerScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    //=========Updates===========
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }
    }
}
