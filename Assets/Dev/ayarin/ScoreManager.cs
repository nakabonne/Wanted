using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

	public int[] ranking = new int[4];
	public int[] stock = new int[4];
	public int top = 0;

	//死んだ時点でセット
	public void SetRanking(int playerID){
		ranking [top] = playerID;
		top++;
	}

	//player側でstockを送る処理
	public void NowScore(int playerID, int playerStock){
		Debug.Log (playerID + "," + playerStock);
		stock [playerID - 1] = playerStock;
	}

	//最終決定
	public void DecidedScore(){
		while (top < GameDataManager.Instance.PlayerIDList.Count) {
			int min = 0;
			for (int i = 0; i < GameDataManager.Instance.PlayerIDList.Count; i++) {
				if (stock [i] != 0) {
					if (stock [min] > stock [i]) {
						min = i;
					}
				}
			}
			SetRanking (min);
			stock [min] = 0;
		}
	}
}
