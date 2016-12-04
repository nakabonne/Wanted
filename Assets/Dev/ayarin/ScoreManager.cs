using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

	public int[] ranking = new int[4];
	public int top = 0;

	//死んだ時点でセット
	public void SetRanking(int playerID){
		ranking [top] = playerID;
		top++;
	}

	//最終決定
	public void DecidedScore(){
		while (top < GameDataManager.Instance.PlayerIDList.Count) {
			int min = 0;
			for (int i = 0; i < GameDataManager.Instance.PlayerIDList.Count; i++) {
				if (PlayerHPManager.Instance.playerHP[i] != 0) {
					if (PlayerHPManager.Instance.playerHP[min] > PlayerHPManager.Instance.playerHP[i]) {
						min = i;
					}
				}
			}
			SetRanking (min);
			PlayerHPManager.Instance.playerHP[min] = 0;
		}
	}
}
