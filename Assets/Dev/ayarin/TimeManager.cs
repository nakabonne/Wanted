using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	[SerializeField]
	static float timeLimit = 100;
	float time;

	bool isStarted = false;

	public Text timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isStarted) {
			CountDown ();
		}

	}

	void InitTimer(){
		time = timeLimit;
	}

	void CountDown(){
		if (time > 0) {
			time -= Time.deltaTime;
			timer.text = time.ToString ();
		}
	}
}
