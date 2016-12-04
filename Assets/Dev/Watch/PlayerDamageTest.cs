using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDamageTest : MonoBehaviour {

	//爆風を受けた時の処理
	public void ReceiveBlast()
	{
		transform.DOLocalMove (new Vector3 (3f, 2, 0), 2f).SetEase (Ease.InOutQuart);
	}
	public int[] playerHp = new int[4];

	void Start()
	{
		playerHp [0] = 1;
		Debug.Log (playerHp [0]);
	}
}