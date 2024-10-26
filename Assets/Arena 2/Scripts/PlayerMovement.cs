using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody rigid;
    private float xInput;
    private float zInput;


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
    }
    private void Inputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rigid.AddForce(new Vector3(xInput, 0f, zInput)*speed);
    } 

}
