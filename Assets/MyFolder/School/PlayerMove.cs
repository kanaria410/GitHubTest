using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private int jumpcount;           //ジャンブした回数をカウント
    public Rigidbody rb;             //body獲得      
    public float jumpPower;          //ジャンプ力
    public float speed;              //移動スピード

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpcount < 2)
        {
            rb.AddForce(new Vector3(0, jumpPower * 45.0f, 0));
            jumpcount++;
        }
    }

    void Update()
    {
        if (Input.GetKey("right"))
        {
            transform.position += transform.right * speed * Time.deltaTime;
            Debug.Log("右に動く");
        }

        if (Input.GetKey("left"))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
            Debug.Log("左に動く");
        }

        Jump();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpcount = 0;
            Debug.Log("初期化済み");
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Ground")
    //    {
    //        jumpcount = 0;
    //        Debug.Log("初期化済み");
    //    }
    //}
}
