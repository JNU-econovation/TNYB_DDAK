using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallTissueMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float randPowerStandard = 10.0f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
        rb2d.AddForce(Vector3.up * randPower);
    }

    private void OnMouseDown()
    {
        GameManager.Instance.clickTissue();
        if (GameManager.Instance.getNumberOfTissue() == 0)
        {
            GameManager.Instance.setIsClear(true);
        }
        GameManager.Instance.changePriceText(500);
        GameManager.Instance.playScannerSound();
        Destroy(gameObject, 0.01f);
    }

    public void Click()
    {
        // 
        // 점수 +
    }
}
