using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class UpwardTrap : MonoBehaviour
{
    public float pushForce = 5f; // Kekuatan dorongan ke atas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Pastikan objek yang memasuki trigger adalah pemain
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null) // Pastikan pemain memiliki Rigidbody
            {
                // Dorong pemain ke atas
                playerRb.AddForce(Vector3.up * pushForce, ForceMode.Impulse);
            }
        }
    }
}