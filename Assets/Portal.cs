using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Target lokasi yang menjadi tujuan portal
    public Transform targetLocation;

    // Event ketika player memasuki portal
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pindahkan player ke lokasi baru
            other.transform.position = targetLocation.position;
        }
    }
}