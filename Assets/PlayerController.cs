using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    // Update is called once per frame
    void fixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Hori");
        float moveVertical = Input.GetAxis("Ver");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed * Time.deltaTime);
        
    }
}
