using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform[] teleportLocations; // Array untuk menyimpan lokasi teleportasi

    private void Start()
    {
        // Menambah lokasi teleportasi secara manual
        AddTeleportLocation(new Vector3(0, 1, 0)); // Lokasi 1
        AddTeleportLocation(new Vector3(5, 1, 0)); // Lokasi 2
        AddTeleportLocation(new Vector3(-5, 1, 0)); // Lokasi 3
        AddTeleportLocation(new Vector3(0, 1, 5)); // Lokasi 4
        AddTeleportLocation(new Vector3(0, 1, -5)); // Lokasi 5
        AddTeleportLocation(new Vector3(2, 1, 2)); // Lokasi 6
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Pastikan objek yang memasuki trigger adalah pemain
        {
            TeleportPlayer(other.transform);
        }
    }

    private void TeleportPlayer(Transform player)
    {
        if (teleportLocations.Length > 0) // Pastikan ada lokasi teleportasi
        {
            // Pilih lokasi acak dari array
            int randomIndex = Random.Range(0, teleportLocations.Length);
            Vector3 randomLocation = teleportLocations[randomIndex].position;

            // Teleportasi pemain ke lokasi yang dipilih
            player.position = randomLocation;
        }
    }

    private void AddTeleportLocation(Vector3 position)
    {
        // Membuat GameObject baru untuk lokasi teleportasi
        GameObject newLocation = new GameObject("TeleportLocation");
        newLocation.transform.position = position;

        // Menambahkan lokasi ke dalam array teleportLocations
        System.Array.Resize(ref teleportLocations, teleportLocations.Length + 1);
        teleportLocations[teleportLocations.Length - 1] = newLocation.transform;
    }
}