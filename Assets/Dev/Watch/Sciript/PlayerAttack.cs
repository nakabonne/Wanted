using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	
	public GameObject bomb;
	public GameObject beam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			PutBom ();
		}
		if (Input.GetMouseButtonDown (1)) {
			PutBeam ();
		}
		
	}
	//ビームを出す
	void PutBeam()
	{
		Instantiate (beam, transform.position, Quaternion.identity);
	}
	//ボムを置く
	void PutBom()
	{
		Instantiate (bomb, transform.position, Quaternion.identity);
	}
}
