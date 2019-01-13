using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheeseMove : MonoBehaviour
{
	private Rigidbody2D rb2d;
	[SerializeField]private float forceHorizontalPower = 2.0f;
	[SerializeField]private float torquePower = 300.0f;
	private const string bottomTag = "bottom";
	private int leftRight;
	private bool isBounced = false;
	
	// Use this for initialization
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	public virtual void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log(col.gameObject);
		
		if (isBounced)
		{
			return;
		}
		isBounced = true;
		
		if (col.gameObject.tag.Equals(bottomTag))
		{
			leftRight = Random.Range(0, 2);
			float randomForceHorizontalPower = Random.Range(forceHorizontalPower - 30, forceHorizontalPower + 30);
		
			if (leftRight == 0)
			{
				rb2d.AddForce(Vector3.left * randomForceHorizontalPower);
				rb2d.AddTorque(torquePower);
			}
			else
			{
				rb2d.AddForce(Vector3.right * randomForceHorizontalPower);
				rb2d.AddTorque(-torquePower);
			}
		}
	}
}
