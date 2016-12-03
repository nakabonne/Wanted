﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	[SerializeField]
	static float timeLimit = 100;
	public float time = timeLimit;
	[SerializeField]
	bool isStarted = false;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		if (isStarted) {
			CountDown ();
		}
	}

	public void InitTimer(){
		time = timeLimit;
	}

	public void StartTimer(){
		isStarted = true;
	}

	void CountDown(){
		if (time > 0) {
			time -= Time.deltaTime;
		}
	}

	public void EndCount(){
		isStarted = false;
	}
}
