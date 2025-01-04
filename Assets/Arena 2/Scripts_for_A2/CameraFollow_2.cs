using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_2 : MonoBehaviour
{
    public Transform target;  // Referensi ke pemain (player)
    public Vector3 offset;    // Jarak kamera dari pemain
    public float smoothSpeed = 0.125f;  // Kehalusan gerakan kamera

    void LateUpdate()
    {
        if (target != null)
        {
            // Hitung posisi target dengan offset
            Vector3 desiredPosition = target.position + offset;

            // Lerp untuk pergerakan kamera yang halus
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Terapkan posisi kamera
            transform.position = smoothedPosition;

            // Pastikan kamera tetap melihat ke arah pemain
            transform.LookAt(target.position);
        }
    }
}