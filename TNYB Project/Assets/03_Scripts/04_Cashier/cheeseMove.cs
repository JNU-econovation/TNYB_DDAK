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
	
	public AudioClip boing1;
	public AudioClip boing2;
	private AudioSource audioSource;
	private List<AudioClip> audioClipList = new List<AudioClip>();
	
	// Use this for initialization
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		
		audioSource = GetComponent<AudioSource>();
		audioClipList.Add(boing1);
		audioClipList.Add(boing2);
	}

	public virtual void OnCollisionEnter2D(Collision2D col)
	{		
		if (isBounced)
		{
			playBoingSound();
			return;
		}
		playBoingSound();
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
	
	private void playBoingSound()
	{
		int randIndex = Random.Range(0, audioClipList.Count);
		audioSource.clip = audioClipList[randIndex];
		audioSource.Play();
	}
}
