using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrail : MonoBehaviour
{
    public GameObject waterDecalPrefab;  // Prefab decal genangan air
    public float decalLifetime = 3.0f;   // Waktu hidup decal

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Membuat decal pada posisi bola
            CreateWaterDecal(transform.position);
        }
    }

    void CreateWaterDecal(Vector3 position)
    {
        // Instantiate decal prefab
        GameObject decal = Instantiate(waterDecalPrefab, position, Quaternion.identity);
        // Set warna decal agar sesuai dengan warna air
        Renderer decalRenderer = decal.GetComponent<Renderer>();
        decalRenderer.material.color = new Color(0.125f, 0.698f, 0.667f); // Sky Blue

        // Menghapus decal setelah waktu tertentu
        Destroy(decal, decalLifetime);
    }
}
