using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marchandise : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public float randPowerStandard = 10.0f;
	
	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
		rb2d.AddForce(Vector3.up * randPower);
	}

	private void OnMouseDown()
	{
		GameManager.Instance.setIsClear(true);
		Destroy(gameObject, 0.1f);
	}

	public void Click()
	{
		// 
		// 점수 +
	}
}
