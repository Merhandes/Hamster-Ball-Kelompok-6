using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerOnContact_2 : MonoBehaviour
{
    [Header("Drag StartPoint Here")]
    public Transform startPoint;  // Titik awal untuk reset player
    public Collider specificTriggerArea; // Collider khusus untuk area tertentu

    private void OnTriggerEnter(Collider other)
    {
        // Pastikan player menyentuh bagian tertentu (TriggerArea)
        if (other.CompareTag("Player") && IsInSpecificArea(other))
        {
            ResetPlayerPosition(other.gameObject);
        }
    }

    private bool IsInSpecificArea(Collider player)
    {
        if (specificTriggerArea != null)
        {
            return specificTriggerArea.bounds.Contains(player.transform.position);
        }
        return false;
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