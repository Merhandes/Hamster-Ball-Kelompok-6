using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timer = 60f; // set waktu 60 detik
    public TextMeshProUGUI timerText;

    public Transform startPoint; // posisi awal bola
    public bool gameActive = true;

    void Update()
    {
        if (gameActive)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Max(timer, 0).ToString("F2");

            if (timer <= 0)
            {
                gameActive = false;
                timerText.text = "Game Over!";
            }
        }
    }

    public void ResetBallPosition(GameObject Player){
        Player.transform.position = startPoint.position;
        Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Debug.Log("Ball reset to start position."); // Tambahkan ini untuk cek
    }
}

