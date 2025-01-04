using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointManager : MonoBehaviour
{
    void Start()
    {
        // Ambil tag spawn point yang telah disimpan
        string spawnTag = PlayerPrefs.GetString("SpawnPoint", "StartPoint");

        // Temukan StartPoint dengan tag yang sesuai
        GameObject startPoint = GameObject.FindWithTag(spawnTag);

        if (startPoint != null)
        {
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                // Pindahkan player ke posisi StartPoint
                player.transform.position = startPoint.transform.position;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;  // Hentikan pergerakan player
            }
        }
        else
        {
            Debug.LogWarning("StartPoint with tag " + spawnTag + " not found!");
        }
    }
}