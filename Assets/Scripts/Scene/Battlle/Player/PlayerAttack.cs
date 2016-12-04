using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IPlayerAttack {
	
	public GameObject bomb;
	bool isBomb = false;

	private PlayerModel _model;

	// Use this for initialization
	void Start () {
		_model = this.GetComponent<PlayerModel> ();
		PlayerInput.Instance.playerAttackMap.Add (_model.PlayerID, this);
	}
	
	// Update is called once per frame
	void Update () {
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
		if (isBomb == false) {
			Debug.Log ("Bombおくよ");
			Instantiate (bomb, transform.position + Vector3.up * 0.5f, Quaternion.identity);
			isBomb = true;
			StartCoroutine (PutBombCoroutine ());
		}
	}

	IEnumerator PutBombCoroutine(){
		yield return new WaitForSeconds (1f);
		Debug.Log ("bomb");
		isBomb = false;
	}
}
