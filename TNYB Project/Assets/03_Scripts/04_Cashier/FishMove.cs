using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour {

	public PhysicsMaterial2D pm2d;
	
	// Use this for initialization
	void Start ()
	{
		pm2d.bounciness = Random.Range(0.9f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
