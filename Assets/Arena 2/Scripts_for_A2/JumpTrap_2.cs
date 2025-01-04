using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrap_2 : MonoBehaviour
{
    public Vector3 launchDirection = new Vector3(0, 1, 0);  // Arah dorongan (default: ke atas)
    public float launchForce = 10f;  // Kekuatan dorongan

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // Deteksi tabrakan dengan player
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Reset kecepatan vertikal player sebelum menambahkan dorongan baru
                playerRb.velocity = Vector3.zero;

                // Terapkan gaya dorong ke arah yang diinginkan
                playerRb.AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
            }
        }
    }
}