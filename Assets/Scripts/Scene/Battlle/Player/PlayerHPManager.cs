using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerHPManager : SingletonMonoBehaviour<PlayerHPManager> {

	public GameObject[] playerHpImage = new GameObject[4];
	PlayerModel playerModel;

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
	}

	public void ShowHP(int playerID, int stock){
		Debug.Log("落ちた");
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
