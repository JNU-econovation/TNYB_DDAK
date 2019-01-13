using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherryMove : MonoBehaviour {

	private Rigidbody2D rb2d;
	[SerializeField]private float forceUpPower = 50.0f;
	
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Start ()
	{
		float randomForceUpPower = Random.Range(forceUpPower - 50, forceUpPower + 50);
		rb2d.AddForce(Vector3.up * randomForceUpPower);
	}
}
