using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;        // Transform player yang akan diikuti
    public float smoothSpeed = 0.125f;  // Kecepatan transisi kamera
    public Vector3 offset;          // Jarak offset dari kamera ke player

    private void Start()
    {
        // Jika belum mengatur offset, atur dengan jarak default
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 5, -10);  // Contoh: Kamera berada di belakang player dan sedikit lebih tinggi
        }
    }

    private void LateUpdate()
    {
        // Posisi yang diinginkan berdasarkan posisi player + offset
        Vector3 desiredPosition = player.position + offset;

        // Menghaluskan gerakan kamera dengan lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atur posisi kamera ke posisi yang sudah disesuaikan
        transform.position = smoothedPosition;

        // Kamera selalu menghadap ke arah player
        transform.LookAt(player);
    }
}
