using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerOnContact : MonoBehaviour
{
    [Header("Drag StartPoint Here")]
    public Transform startPoint;  // Titik awal untuk reset player

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetPlayerPosition(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResetPlayerPosition(other.gameObject);
        }
    }

    private void ResetPlayerPosition(GameObject player)
    {
        if (startPoint != null)
        {
            player.transform.position = startPoint.position;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Debug.Log("Player reset to StartPoint.");
        }
        else
        {
            Debug.LogWarning("StartPoint not assigned in inspector!");
        }
    }
}