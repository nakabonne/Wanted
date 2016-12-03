using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectView : MonoBehaviour {

	public GameObject test;

	[SerializeField]
	private Transform[] showPos;

	// プレイヤーを表示
	public void ShowPlayer(int playerID){
		Instantiate (test, showPos [playerID].position, Quaternion.identity);
	}
}
