using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

	public int[] ranking = new int[4];
	public int[] playerHp = new int[4];
	public int top = 0;

	public void Init(){
		top = 0;
	}

	//死んだ時点でセット
	public void SetRanking(int playerID){
		ranking [top] = playerID;
		top++;
	}

	public void SetHP(int playerID, int HP){
		playerHp [playerID - 1] = HP;
	}
		
	//最終決定
	public void DecidedScore(){
		while (top < GameDataManager.Instance.PlayerIDList.Count) {
			int min = 6;
			int minPlayer = 0;
			for (int i = 0; i < GameDataManager.Instance.PlayerIDList.Count; i++) {
				if (playerHp [i] != 0) {
					Debug.Log (i);
					if (min > playerHp [i]) {
						min = playerHp[i];
						minPlayer = i;
					}
				}
			}
			SetRanking (minPlayer+1);
			playerHp [minPlayer] = 0;
		}
	}
}
