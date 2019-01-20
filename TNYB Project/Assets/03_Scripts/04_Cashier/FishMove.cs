using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour {

	public PhysicsMaterial2D pm2d;
	private Rigidbody2D rb2d;
	public float randPowerStandard = 10.0f;
	private AudioSource audioSource;
	private const string bottomTag = "bottom";
	
	// Use this for initialization
	void Awake ()
	{
		pm2d.bounciness = Random.Range(0.9f, 1.0f);
		audioSource = GetComponent<AudioSource>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	private void Start()
	{
		audioSource.Play();
		float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
		rb2d.AddForce(Vector3.up * randPower);
	}
	
	public virtual void OnCollisionEnter2D(Collision2D col)
	{	
		if (col.gameObject.tag.Equals(bottomTag))
		{
			audioSource.Play();
		}
	}

	private void OnMouseDown()
	{
		GameManager.Instance.setIsClear(true);
		int price = Random.Range(7, 9) * 1000;
		GameManager.Instance.changePriceText(price);
		GameManager.Instance.playScannerSound();
		Destroy(gameObject, 0.01f);
	}

	public void Click()
	{
		// 
		// 점수 +
	}
}
