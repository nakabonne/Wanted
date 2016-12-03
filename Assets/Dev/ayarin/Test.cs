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
			StartCoroutine(StageManager.GetComponent<Stage>().Beam (this.transform.position,this.transform.forward));
		}
		if (Input.GetKeyDown ("w")) {
			GameManager.GetComponent<GameManager> ().SetBattleStatusWait ();
		}

		if (Input.GetKeyDown ("s")) {
			GameManager.GetComponent<GameManager> ().SetBattleStatusStart ();
		}

		if (Input.GetKeyDown ("e")) {
			GameManager.GetComponent<GameManager> ().SetBattleStatusEnd ();
		}
	}
}
