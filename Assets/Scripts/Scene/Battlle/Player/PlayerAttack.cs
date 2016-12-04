using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IPlayerAttack {
	
	public GameObject bomb;
	//public GameObject beam;

	public GameObject stageObj;

	Stage stage;

	private PlayerModel _model;
	// Use this for initialization
	void Start () {
		_model = this.GetComponent<PlayerModel> ();
		PlayerInput.Instance.playerAttackMap.Add (_model.PlayerID, this);

		stageObj = GameObject.Find ("Stage");
		stage = stageObj.GetComponent<Stage> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			PutBomb ();
		}
		if (Input.GetMouseButtonDown (1)) {
			PutBeam ();
		}
		
	}
	//ビームを出す
	public void PutBeam()
	{
		Debug.Log ("Beamうつよ");
		stage.Beam (this.transform.position, this.transform.forward);
		//Stage.Instance.Beam (this.transform.position, this.transform.forward);
	}
	//ボムを置く
	public void PutBomb()
	{
		Debug.Log ("Bombおくよ");
		Instantiate (bomb, transform.position, Quaternion.identity);
	}
}
