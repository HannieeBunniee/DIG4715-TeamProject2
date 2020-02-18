using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to use UI text

public class GameController : MonoBehaviour
{
    //Audio
    public AudioSource musicSource;
    public AudioClip backgroundAudio;

    //========Start==========
    void Start()
    {
        musicSource.clip = backgroundAudio;
        musicSource.Play();
    }

    //=========Updates===========
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("Quitting Game by esc key");
            Application.Quit();
        }
    }

    
}
