using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marchandise : MonoBehaviour {

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
