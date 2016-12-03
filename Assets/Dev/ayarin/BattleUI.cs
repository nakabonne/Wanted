using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour {

	public GameObject TimeManager;

	public Text timer;
	public Text countDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer.text = TimeManager.GetComponent<TimeManager> ().time.ToString ();
	}

	public void setCountDown(int time){
		if (time == 0) {
			countDown.text = "";
		} else {
			countDown.text = time.ToString ();
		}
	}
}
