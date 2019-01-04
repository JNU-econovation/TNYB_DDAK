﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private Image timeBar;
	public float maxTime = 10f;
	private float timeLeft;
	public GameObject timesUpText;

	// Use this for initialization
	void Start () {
		timesUpText.SetActive(false);
		timeBar = GetComponent<Image>();
		timeLeft = maxTime;
	}
	
	void Update () {
		if (timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
			timeBar.fillAmount = timeLeft / maxTime;
		}
		else
		{
			timesUpText.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
