using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ball entered fall detector area.");

            // Panggil GameManager untuk reset posisi
            if (GameManager.instance != null)
            {
                GameManager.instance.ResetBallPosition(other.gameObject);
            }
        }
    }
}