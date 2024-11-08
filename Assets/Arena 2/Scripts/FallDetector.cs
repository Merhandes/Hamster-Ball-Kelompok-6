using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Pastikan bola memiliki tag "Player"
        {
            Debug.Log("Ball entered fall detector area."); // Log untuk melacak
            gameManager.ResetBallPosition(other.gameObject);
        }
    }
}


