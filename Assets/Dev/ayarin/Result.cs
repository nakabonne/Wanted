using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

	public Text result;

	// Use this for initialization
	void OnEnable () {
		string score = null;

		for (int i = 0; i < GameDataManager.Instance.PlayerIDList.Count; i++) {
			score += (i + 1).ToString () + ". " + ScoreManager.Instance.ranking [GameDataManager.Instance.PlayerIDList.Count -1 -i] + "P\n";
		}

		result.text = score;
	}

}
