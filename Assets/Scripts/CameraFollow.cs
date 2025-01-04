using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Bola atau player sebagai target
    public Vector3 offset = new Vector3(0, 15, -10);  // Jarak kamera dari bola
    public float smoothSpeed = 0.2f;  // Kehalusan gerakan kamera

    void LateUpdate()
    {
        if (target == null) return;

        // Tentukan posisi target dengan offset
        Vector3 desiredPosition = target.position + offset;

        // Buat transisi kamera agar smooth
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Terapkan posisi kamera
        transform.position = smoothedPosition;

        // Arahkan kamera ke bola
        transform.LookAt(target.position);
    }
}