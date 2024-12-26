using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    // Kecepatan boost yang ingin ditambahkan
    public float boostMultiplier = 7f;

    // Durasi boost dalam detik
    public float boostDuration = 3f;

    // Komponen Rigidbody untuk mengatur kecepatan player
    private Rigidbody playerRigidbody;

    // Variabel untuk menyimpan kecepatan normal player
    private float normalSpeed;

    // Menyimpan status boost (aktif atau tidak)
    private bool isBoosting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isBoosting)
        {
            // Menyimpan referensi ke Rigidbody player dan kecepatan normal
            playerRigidbody = other.GetComponent<Rigidbody>();
            normalSpeed = playerRigidbody.velocity.magnitude;

            // Mengaktifkan boost
            StartCoroutine(ActivateBoost());
        }
    }

    private IEnumerator ActivateBoost()
    {
        isBoosting = true;

        // Meningkatkan kecepatan player
        playerRigidbody.velocity = playerRigidbody.velocity.normalized * (normalSpeed * boostMultiplier);

        // Tampilkan efek visual atau suara jika diperlukan
        // (Contoh: Menambahkan efek partikel atau suara)

        // Menunggu selama durasi boost
        yield return new WaitForSeconds(boostDuration);

        // Mengembalikan kecepatan ke normal
        playerRigidbody.velocity = playerRigidbody.velocity.normalized * normalSpeed;

        isBoosting = false;
    }
}
