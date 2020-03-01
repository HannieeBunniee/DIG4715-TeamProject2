﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to use UI text

public class GameController : MonoBehaviour
{
    //Audio
    public AudioSource musicSource;
	public AudioClip backgroundAudio;
    public AudioClip enemyShooting;
    public AudioClip winAudio;
    public AudioClip loseAudio;

    //bool
    public bool regAudio;

    //========Start==========
    void Start()
    {
        regAudio = true;
        musicSource.clip = backgroundAudio;
        musicSource.Play();

    }

    //=========Updates===========
    void Update()
    {
        if (regAudio == false)
        {
            musicSource.Stop();
        }
        
    }

    public void LoseAudio()
    {
        musicSource.Stop();
        musicSource.loop = false;
        musicSource.clip = loseAudio;
        musicSource.Play();
    }

    public void WinAudio()
    {
        musicSource.Stop();
        musicSource.loop = false;
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