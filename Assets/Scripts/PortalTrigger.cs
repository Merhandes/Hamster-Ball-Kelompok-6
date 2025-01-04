using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Tambahkan ini untuk manajemen scene
using UnityEngine.VFX;  // Untuk Visual Effect Graph

public class PortalTrigger : MonoBehaviour
{
    public GameObject portal;               // Portal yang akan diaktifkan
    public VisualEffect portalEffect;       // Efek visual portal
    public Transform player;                // Referensi ke pemain
    public float distanceInFront = 1f;      // Jarak portal di depan pemain
    public string sceneToLoad;              // Scene yang akan di-load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aktifkan portal di depan player
            if (portal != null)
            {
                Vector3 spawnPosition = player.position + player.forward * distanceInFront;
                spawnPosition.y = player.position.y;  // Sesuaikan tinggi portal
                portal.transform.position = spawnPosition;
                portal.SetActive(true);  // Munculkan portal

                // Mainkan efek visual jika ada
                if (portalEffect != null)
                {
                    portalEffect.Play();
                }

                // Pindah ke scene lain setelah sedikit jeda
                StartCoroutine(LoadSceneWithDelay(1f));
            }
        }
    }

    IEnumerator LoadSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Pastikan GameManager tetap hidup dan simpan timer
        if (GameManager.instance != null)
        {
            GameManager.instance.SaveTimer();
        }

        // Pindah ke scene berikutnya
        SceneManager.LoadScene(sceneToLoad);
    }
}