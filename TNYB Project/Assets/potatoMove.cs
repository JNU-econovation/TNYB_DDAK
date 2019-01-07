using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potatoMove : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float forcePower = 2.0f;
	public float rotateSpeed = 1;
	
	// Use this for initialization
	void Start () {
		rb2d.AddForce(Vector3.left * forcePower);
		rb2d.AddForce(Vector3.up * (forcePower * 2) / 3);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.Rotate(Vector3.forward * rotateSpeed);
	}
}
