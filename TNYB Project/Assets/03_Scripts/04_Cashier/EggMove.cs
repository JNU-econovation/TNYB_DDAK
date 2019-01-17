using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMove : MonoBehaviour {

	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	public Sprite CrushedEgg;
	private const string bottomTag = "bottom";
	public float randPowerStandard = 10.0f;
	private bool isCrushed = false;
	
	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		rb2d = GetComponent<Rigidbody2D>();
		
		float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
		rb2d.AddForce(Vector3.up * randPower);
		isCrushed = false;
	}
	
	private void OnMouseDown()
	{
		if(!isCrushed)
		{
			GameManager.Instance.setIsClear(true);
			int price = Random.Range(1, 3) * 1000;
			GameManager.Instance.changePriceText(price);
			Destroy(gameObject, 0.1f);
		}
	}
	
	public virtual void OnCollisionEnter2D(Collision2D col)
	{	
		if (col.gameObject.tag.Equals(bottomTag))
		{
			isCrushed = true;
			sr.sprite = CrushedEgg;
			
			// 얼마 뒤에 제거
			StartCoroutine(IeAlphaDownCoroutine());
			StartCoroutine(IeDestroyCrushedEggAfterWaiting());
		}
	}

	public IEnumerator IeDestroyCrushedEggAfterWaiting()
	{
		yield return new WaitForSeconds(1.5f);
		GameManager.Instance.setIsClear(true);
		Destroy(gameObject, 0.1f);
	}
	
	public IEnumerator IeAlphaDownCoroutine()
	{
		float t = 0.95f;
		
		while (t > 0)
		{
			Color tColor = sr.color;
			t -= 0.02f;
			tColor.a = t;
			sr.color = tColor;
			yield return null;
		}
	}
}