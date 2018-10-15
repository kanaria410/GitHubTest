using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour {

    private int jumpcount;      //ジャンブした回数をカウント
    int state;                  //状態
    [SerializeField,Header("プレイヤーとの距離感")]
    int playerOfDis;            //プレイヤーとの距離
    public float jumpPower;     //ジャンプ力
    public float speed;         //移動スピード
    Vector3 distance;           //プレイヤーとの距離
    GameObject target;          //追いかける対象
    Rigidbody rb;               //body獲得      

    public enum StateType
    {
        IDLE = 1,   //生きている
        WALK = 2,   //歩く
        ATTACK = 3, //攻撃
        AVOID = 4,  //回避
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player");

        //初期化
        state = 1;  //ステートマシーン起動
    }

    void Idle()
    {
        //通常は生きていればtrueになるように書く
        if (true)
        {
            state = (int)StateType.WALK;
        }
    }

    void Walk()
    {
        //自分とプレイヤーの間の距離を計算
        distance = target.transform.position - transform.position;

        if (Mathf.Abs(distance.x) > playerOfDis)
        {
            //state = (int)StateType.ATTACK;

            //プレイヤーが右にいれば右に、左にいれば左に移動
            if (distance.x > 0)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("up") && jumpcount < 2)
        {
            rb.AddForce(new Vector3(0, jumpPower * 45.0f, 0));
            jumpcount++;
        }
    }

    void Update()
    {
        switch (state)
        {
            case 1:
                Idle();
                break;
            case 2:
                Walk();
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumpcount = 0;
            Debug.Log("初期化済み");
        }
    }
}
