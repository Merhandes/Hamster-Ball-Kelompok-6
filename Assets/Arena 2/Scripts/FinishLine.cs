using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.gameActive = false;
            gameManager.timerText.text = "You Win!";
        }
    }
}

