using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timer = 60f;  // Timer awal
    public TextMeshProUGUI timerText;
    public bool gameActive = true;

    public static GameManager instance;  // Singleton instance

    public Transform startPoint;  // Posisi awal bola

    void Awake()
    {
        // Singleton: Pastikan hanya ada satu instance GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Jangan hancurkan saat pindah scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Muat timer yang disimpan sebelumnya (jika ada)
        if (PlayerPrefs.HasKey("TimerValue"))
        {
            timer = PlayerPrefs.GetFloat("TimerValue");

            // Validasi timer agar tidak terlalu besar atau terlalu kecil
            if (timer > 60f || timer < 0f)
            {
                timer = 60f;  // Reset ke nilai awal jika tidak valid
            }
        }

        // Sinkronisasi UI
        UpdateTimerUI();
    }

    void Update()
    {
        if (gameActive)
        {
            timer -= Time.deltaTime;
            UpdateTimerUI();

            if (timer <= 0)
            {
                gameActive = false;
                timerText.text = "Game Over!";
            }
        }
    }

    // Simpan waktu saat berpindah scene
    public void SaveTimer()
    {
        PlayerPrefs.SetFloat("TimerValue", timer);
        PlayerPrefs.Save();
    }

    // Reset posisi bola ke startPoint
    public void ResetBallPosition(GameObject player)
    {
        if (startPoint != null)
        {
            player.transform.position = startPoint.position;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;  // Hentikan pergerakan
            Debug.Log("Ball reset to start position.");
        }
        else
        {
            Debug.LogWarning("Start point not assigned in GameManager.");
        }
    }

    // Load timer saat scene baru dimuat
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (PlayerPrefs.HasKey("TimerValue"))
        {
            timer = PlayerPrefs.GetFloat("TimerValue");
        }

        // Sinkronisasi ulang UI Text di scene baru
        TextMeshProUGUI newTimerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();
        if (newTimerText != null)
        {
            timerText = newTimerText;
            UpdateTimerUI();
        }
        else
        {
            Debug.LogWarning("TimerText not found in new scene.");
        }

        // Coba cari startPoint di scene baru
        GameObject startPointObj = GameObject.FindWithTag("StartPoint");
        if (startPointObj != null)
        {
            startPoint = startPointObj.transform;
        }
        else
        {
            Debug.LogWarning("StartPoint not found in this scene.");
        }
    }

    // Update UI Timer
    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Max(timer, 0).ToString("F2");
        }
    }

    // Reset Timer ke Awal
    public void ResetTimer(float newTime = 60f)
    {
        timer = newTime;
        PlayerPrefs.SetFloat("TimerValue", timer);
        PlayerPrefs.Save();
        UpdateTimerUI();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}