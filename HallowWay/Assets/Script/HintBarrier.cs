using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintBarrier : MonoBehaviour
{
    public GameObject hintText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintText.SetActive(false);
        }
    }
}
