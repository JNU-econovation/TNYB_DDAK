﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject hand;
	public Transform handTf1, handTf2, handTf3;
	private List<Transform> handTfList = new List<Transform>();
	public static int handTfIndex;
	
	public Transform marchandiseTf1, marchandiseTf2, marchandiseTf3;
	private List<Transform> marchandiseTfList = new List<Transform>();
	
	List<GameObject> marchandisePrefabsList = new List<GameObject>();
	public GameObject marchandise1, marchandise2, marchandise3, marchandise4, marchandise5, marchandise6, marchandise7;

	private bool bCanHandRespawn = false;
	private bool bCanMarchandiseRespawn = false;
	private bool isClear = true;

	private static GameManager instance;

	public static GameManager Instance
	{
		get { return instance; }
	}

	private void Awake()
	{
		if (instance)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
		
		handTfList.Add(handTf1);
		handTfList.Add(handTf2);
		handTfList.Add(handTf3);
		
		marchandiseTfList.Add(marchandiseTf1);
		marchandiseTfList.Add(marchandiseTf2);
		marchandiseTfList.Add(marchandiseTf3);
		
		marchandisePrefabsList.Add(marchandise1);
		marchandisePrefabsList.Add(marchandise2);
		marchandisePrefabsList.Add(marchandise3);
		marchandisePrefabsList.Add(marchandise4);
		marchandisePrefabsList.Add(marchandise5);
		marchandisePrefabsList.Add(marchandise6);
		marchandisePrefabsList.Add(marchandise7);
	}
	
	void Start ()
	{
		bCanHandRespawn = true;
	}

	private void FixedUpdate()
	{
		if (bCanHandRespawn && isClear)
		{
			RespawnRandomTfHand();
		}
		
		if (bCanMarchandiseRespawn)
		{
			RespawnMarchandise();
			bCanMarchandiseRespawn = false;
		}
	}

	private void RespawnRandomTfHand()
	{
		bCanHandRespawn = false;
		handTfIndex = Random.Range(0, handTfList.Count);
		GameObject tempHand;
		tempHand = Instantiate(hand);
		tempHand.transform.position = handTfList[handTfIndex].position;
	}
	
	public void RespawnMarchandise()
	{
		isClear = false;

		int marchandiseIndex = Random.Range(0, marchandisePrefabsList.Count);
		
		GameObject tempMarchandise;
		tempMarchandise = Instantiate(marchandisePrefabsList[marchandiseIndex]);
		tempMarchandise.transform.position = marchandiseTfList[handTfIndex].position;
	}

	public void setbCanHandRespawn(bool b)
	{
		bCanHandRespawn = b;
	}
	
	public void setbCanMarchandiseRespawn(bool b)
	{
		bCanMarchandiseRespawn = b;
	}

	public void setIsClear(bool b)
	{
		isClear = b;
	}
}
