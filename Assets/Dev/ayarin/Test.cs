using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public GameObject StageManager;
	public GameObject GameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			Stage.Instance.Beam(this.transform.position,this.transform.eulerAngles.y);
		}

		if(Input.GetKeyDown(KeyCode.S)){
			GameManager.GetComponent<GameManager> ().SetBattleStatus (global::GameManager.BattleStatus.WAIT);
		}
	}
}
