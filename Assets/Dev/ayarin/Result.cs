using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

	public Text result;

	// Use this for initialization
	void Start () {
		result.text = "1. " + ScoreManager.Instance.ranking[0] + "P\n"
			+ "2. " + ScoreManager.Instance.ranking[1] + "P\n"
			+ "3. " + ScoreManager.Instance.ranking[2] + "P\n"
			+ "4. " + ScoreManager.Instance.ranking[3] + "P\n";
	}

}
