using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUI : MonoBehaviour {

	public GameObject TimeManager;

	public Text timer;
	public Text countDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer.text = TimeManager.GetComponent<TimeManager> ().time.ToString ("f2");
	}

	public void setCountDown(int time){
		if (time == 0) {
			countDown.text = "START";
			countDown.gameObject.transform.DOShakeScale (1f).OnComplete(() =>{
				countDown.text = "";
			});
		} else {
			countDown.text = time.ToString ();
			countDown.gameObject.transform.DOPunchScale (new Vector3 (1f, 1f, 1f), 0.85f, 1, 0).OnComplete(() =>{
				countDown.text = "";
			});
		}
	}
}
