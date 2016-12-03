using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

	public int[] ranking = new int[4];
	int top = 0;

	public void SetRanking(int playerID){
		ranking [top] = playerID;
		top++;
	}
}
