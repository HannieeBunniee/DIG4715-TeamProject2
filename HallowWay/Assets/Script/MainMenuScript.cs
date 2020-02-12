﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f; //unfreeze the game (incase they decided to play AFTER going main menu from pause menu)
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
