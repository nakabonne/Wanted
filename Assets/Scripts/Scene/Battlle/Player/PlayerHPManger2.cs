using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerHPManager2 : SingletonMonoBehaviour<PlayerHPManager> {

	public GameObject[] playerHpImage = new GameObject[4];
	private int[] playerHp = new int[4];

	

	public void SetPlayerHP(int n, int hp){
		playerHp [n] = hp;
	}

	public int GetPlayerHP(int n){
		return playerHp [n];
	}



	// 次からはリスト使ったほうがいいよ！
//	private List<int> playerHPList = new List<int>();
//
//	private void AddPlayerHP(int num){
//		playerHPList.Add (num);
//	}
//
//	private void SetPlayerHP(int n, int num){
//		playerHPList[n] = num;
//	}

	void Start(){
		switch (GameDataManager.Instance.PlayerIDList.Count) {
		case 4:
			break;
		case 3:
			playerHpImage [3].SetActive (false);
			break;
		case 2:
			playerHpImage [3].SetActive (false);
			playerHpImage [2].SetActive (false);
			break;
		case 1:
			playerHpImage [3].SetActive (false);
			playerHpImage [2].SetActive (false);
			playerHpImage [1].SetActive (false);
			break;
		}

		//---------------

	}


	public void ShowHP(int playerID, int stock){
		switch (stock) {
		case 4:
			playerHpImage [playerID - 1].transform.FindChild ("hp5").gameObject.SetActive (false);
			break;
		case 3:
			playerHpImage [playerID - 1].transform.FindChild ("hp4").gameObject.SetActive (false);
			break;
		case 2:
			playerHpImage [playerID - 1].transform.FindChild ("hp3").gameObject.SetActive (false);
			break;
		case 1:
			playerHpImage [playerID - 1].transform.FindChild ("hp2").gameObject.SetActive (false);
			break;
		case 0:
			playerHpImage [playerID - 1].transform.FindChild ("hp1").gameObject.SetActive (false);
			break;
		}
	}


}
