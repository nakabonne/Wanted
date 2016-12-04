using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IPlayerAttack {
	
	public GameObject bomb;

	private PlayerModel _model;

	// Use this for initialization
	void Start () {
		_model = this.GetComponent<PlayerModel> ();
		PlayerInput.Instance.playerAttackMap.Add (_model.PlayerID, this);
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
		Stage.Instance.Beam (this.transform.position, this.transform.eulerAngles.y);
	}
	//ボムを置く
	public void PutBomb()
	{
		Debug.Log ("Bombおくよ");
		Instantiate (bomb, transform.position + Vector3.up * 0.25f, Quaternion.identity);
	}
}
