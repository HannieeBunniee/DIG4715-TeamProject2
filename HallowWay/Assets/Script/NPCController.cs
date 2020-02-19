using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public Text pressXText;
    public GameObject textBoxActive;
    private bool talkAllowed;


    private void Update()
    {
        if(talkAllowed && Input.GetKeyDown(KeyCode.X))
        {
            textBoxActive.SetActive(true);
            Time.timeScale = 0f; //freeze the game
            Cursor.lockState = CursorLockMode.None; //unlock cursorLock so they can click buttons
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pressXText.gameObject.SetActive(true);
            talkAllowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pressXText.gameObject.SetActive(false);
            talkAllowed = false;
        }
    }
}
