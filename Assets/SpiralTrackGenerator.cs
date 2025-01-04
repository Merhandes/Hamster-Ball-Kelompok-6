using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralTrackGenerator : MonoBehaviour
{
    [SerializeField]public GameObject cylinderPrefab;  // Prefab atau brush silinder yang akan digunakan
    public int numberOfSteps = 36;     // Jumlah langkah untuk satu putaran penuh (360°)
    public float heightIncrement = 0.5f;  // Kenaikan tinggi tiap silinder
    public float rotationIncrement = 10f; // Rotasi per langkah (derajat)

    void Start()
    {
        GenerateSpiral();
    }

    void GenerateSpiral()
    {
        if (cylinderPrefab == null)
        {
            Debug.LogError("Cylinder Prefab is not assigned!");
            return;
        }

        for (int i = 0; i < numberOfSteps; i++)
        {
            // Membuat duplikasi silinder
            GameObject step = Instantiate(cylinderPrefab, transform);

            // Mengatur posisi dan rotasi
            step.transform.localPosition = new Vector3(0, i * heightIncrement, 0);
            step.transform.localRotation = Quaternion.Euler(0, i * rotationIncrement, 0);
        }
    }
}