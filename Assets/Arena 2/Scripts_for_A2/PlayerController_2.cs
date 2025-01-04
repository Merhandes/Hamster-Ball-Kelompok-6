using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Tambahkan namespace TextMeshPro
using UnityEngine.SceneManagement;  // Tambahkan untuk pindah scene

public class PlayerController_2 : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody rigid;

    // Input yang dapat disesuaikan
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    private float xInput;
    private float zInput;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    private int count;

    public GameObject portalPrefab;  // Prefab portal
    private bool portalSpawned = false; // Cek apakah portal sudah muncul

    void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        count = 0; // Inisialisasi count
        SetCountText(); // Perbarui UI di awal
        winText.text = ""; // Kosongkan teks kemenangan di awal
    }

    private void Inputs()
    {
        xInput = 0f;
        zInput = 0f;

        if (Input.GetKey(forwardKey)) zInput = 1;
        if (Input.GetKey(backwardKey)) zInput = -1;
        if (Input.GetKey(leftKey)) xInput = -1;
        if (Input.GetKey(rightKey)) xInput = 1;
    }

    private void Move()
    {
        rigid.AddForce(new Vector3(xInput, 0f, zInput) * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

        // Jika menyentuh portal, pindah ke scene lain
        if (other.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("NextScene");  // Ganti dengan nama scene tujuan
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        int targetCount = 1;  // Ubah sesuai jumlah item yang dibutuhkan

        // Log kondisi count terkini
        Debug.Log("Current Count: " + count + ", PortalSpawned: " + portalSpawned);

        // Pastikan portal muncul jika jumlah sudah cukup
        if (count >= targetCount && !portalSpawned)
        {
            SpawnPortal();
            Debug.Log("Portal has been spawned at count: " + count);
        }
        else if (count < targetCount)
        {
            Debug.Log("Not enough count to spawn portal. Current count: " + count + " / " + targetCount);
        }
        else
        {
            Debug.Log("Portal already spawned, no further action.");
        }
    }

    // Fungsi memunculkan portal di depan player
    void SpawnPortal()
    {
        if (portalPrefab != null)
        {
            // Munculkan portal di depan player sesuai arah yang dituju
            Vector3 spawnPosition = transform.position + transform.forward * 2f;  // 2 unit di depan player
            spawnPosition.y = transform.position.y;  // Sesuaikan ketinggian portal dengan player

            Instantiate(portalPrefab, spawnPosition, Quaternion.identity);
            portalSpawned = true;  // Tandai portal sudah muncul
            Debug.Log("Portal Spawned in front of the player!");
        }
        else
        {
            Debug.LogWarning("Portal prefab tidak diset di Inspector!");
        }
    }
}