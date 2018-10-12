using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject target;
    Vector3 targetPos;
	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //ターゲットのほうを向く
        transform.LookAt(target.transform.position);
        targetPos = target.transform.position;
        //ターゲットに向かって進む
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 1 * Time.deltaTime);
	}
}
