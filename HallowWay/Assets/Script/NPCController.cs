using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    //public Text pressXText;
    public GameObject pressX;
    public GameObject textBoxActive;
    private bool talkAllowed;


    private void Update()
    {
        if(talkAllowed && Input.GetKeyDown(KeyCode.X))
        {
            pressX.SetActive(false);
            textBoxActive.SetActive(true);
            Time.timeScale = 0f; //freeze the game
            Cursor.lockState = CursorLockMode.None; //unlock cursorLock so they can click buttons
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //pressXText.gameObject.SetActive(true);
            pressX.SetActive(true);
            talkAllowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //pressXText.gameObject.SetActive(false);
            pressX.SetActive(false);
            talkAllowed = false;
        }
    }
}
