﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class IngameMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool winLoseCondition = false;
    public GameObject pauseMenuUI;

    private bool optionOn = false;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && winLoseCondition == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else if (optionOn == false)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //unfreeze the game
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked; //lock cursorLock after menu
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //freeze the game
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None; //unlock cursorLock so they can click buttons
    }

    public void LoadMenu()
    {
        //Debug.Log("Loading Menu");
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f; //unfreeze the game
        Cursor.lockState = CursorLockMode.None; //unlock cursorLock so they can click buttons
    }

    public void optionMenu()
    {
        optionOn = true;
    }

    public void backButton()
    {
        optionOn = false;
    }
}
