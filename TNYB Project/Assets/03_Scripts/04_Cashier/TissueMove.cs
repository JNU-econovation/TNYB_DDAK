﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TissueMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float randPowerStandard = 10.0f;

    public GameObject tissue1;
    public GameObject tissue2;
    private List<GameObject> tissueList = new List<GameObject>();

    private void Awake()
    {
        tissueList.Add(tissue1);
        tissueList.Add(tissue2);
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
        rb2d.AddForce(Vector3.up * randPower);
    }

    private void OnMouseDown()
    {
        RespawnTissues();
//        GameManager.Instance.setIsClear(true);
//        int price = Random.Range(1, 9) * 1000;
//        GameManager.Instance.changePriceText(price);
        GameManager.Instance.playScannerSound();
        GameManager.Instance.generateTissue();
        Destroy(gameObject, 0.01f);
    }

    private void RespawnTissues()
    {
        GameObject tempTissue1, tempTissue2, tempTissue3, tempTissue4;
        
        int randIndex = Random.Range(0, tissueList.Count);
        tempTissue1 = Instantiate(tissueList[randIndex]);
        tempTissue1.transform.position = this.transform.position + Vector3.left * 0.2f + Vector3.up * 0.2f;
        
        randIndex = Random.Range(0, tissueList.Count);
        tempTissue2 = Instantiate(tissueList[randIndex]);
        tempTissue2.transform.position = this.transform.position + Vector3.right * 0.2f + Vector3.up * 0.2f;
        
        randIndex = Random.Range(0, tissueList.Count);
        tempTissue3 = Instantiate(tissueList[randIndex]);
        tempTissue3.transform.position = this.transform.position + Vector3.left * 0.2f + Vector3.down * 0.2f;
        
        randIndex = Random.Range(0, tissueList.Count);
        tempTissue4 = Instantiate(tissueList[randIndex]);
        tempTissue4.transform.position = this.transform.position + Vector3.right * 0.2f + Vector3.down * 0.2f;
    }

    public void Click()
    {
        // 
        // 점수 +
    }
}
