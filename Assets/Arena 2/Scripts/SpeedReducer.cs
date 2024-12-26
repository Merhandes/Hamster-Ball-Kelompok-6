using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedReducer : MonoBehaviour
{
    public float minSlowDownFactor = 0.1f; // Faktor perlambatan minimum
    public float velocityThreshold = 5f;   // Kecepatan di atas mana perlambatan akan maksimal

    private void OnTriggerStay(Collider other)
    {
        // Pastikan objek yang masuk ke area air adalah bola atau objek dengan Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Dapatkan kecepatan saat ini dari bola
            float currentSpeed = rb.velocity.magnitude;

            // Hitung maxSlowDownFactor berdasarkan kecepatan bola saat ini
            // 90% dari kecepatan saat ini
            float maxSlowDownFactor = Mathf.Clamp(currentSpeed * 0.9f, minSlowDownFactor, 1f);

            // Terapkan perlambatan ke kecepatan bola, dengan memperlambat sesuai dengan maxSlowDownFactor
            rb.velocity *= (1 - maxSlowDownFactor * Time.deltaTime);
        }
    }
}