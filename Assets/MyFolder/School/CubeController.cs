using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField, Header("スピード")]
    Vector3 speed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Horizontal") != 0) 
        transform.position += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
	}
}
