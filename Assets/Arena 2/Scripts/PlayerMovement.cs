using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Tambahkan namespace TextMeshPro

public class PlayerMovement : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody rigid;
    private float xInput;
    private float zInput;

    // Ganti tipe Text menjadi TextMeshProUGUI
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    private int count;

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        count = 0; // Inisialisasi count
        SetCountText(); // Perbarui UI di awal
        winText.text = ""; // Kosongkan teks kemenangan di awal
    }

    private void Inputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
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
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }
}