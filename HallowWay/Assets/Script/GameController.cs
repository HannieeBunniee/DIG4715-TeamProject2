using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to use UI text

public class GameController : MonoBehaviour
{
    //Audio
    public AudioSource musicSource;
	public AudioClip backgroundAudio;
    public AudioClip winAudio;
    public bool regAudio;
    //========Start==========
    void Start()
    {
        regAudio = true;
        if (regAudio = true)
        {
            musicSource.clip = backgroundAudio;
            musicSource.Play();
        }
        if(regAudio = false)
        {
            musicSource.Stop();
        }
        //musicSource.clip = backgroundAudio;
        //musicSource.Play();
    }

    //=========Updates===========
    void Update()
    {
        
    }

    public void WinAudio()
    {
        musicSource.Stop();
        musicSource.clip = winAudio;
        musicSource.Play();
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