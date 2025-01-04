using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrap : MonoBehaviour
{
    public float jumpForce = 15f;  // Kekuatan dorongan ke atas
    public Animator animator;      // Animator untuk animasi spring
    private float initialYPosition;  // Posisi awal Y dari trap
    private bool canActivate = false;  // Apakah trap bisa diaktifkan

    private void Start()
    {
        initialYPosition = transform.position.y;  // Simpan posisi awal Y
    }

    private void Update()
    {
        // Cek jika posisi trap lebih tinggi 20% dari posisi awal
        if (transform.position.y >= initialYPosition * 1.2f)
        {
            canActivate = true;
        }
        else
        {
            canActivate = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canActivate && other.CompareTag("Player"))  // Hanya aktif jika sudah naik 20%
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Dorong player ke atas
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
        }
    }
}