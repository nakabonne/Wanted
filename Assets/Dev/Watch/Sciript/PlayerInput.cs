using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerInput : MonoBehaviour {
	//最後にpublicにする
	public GameObject[] players = new GameObject[4];

	// Use this for initialization
	void Start () {
		SerchPlayer ();
		SerchController ();
	}
	//プレイヤーをサーチ
	void SerchPlayer()
	{
		players [0] = GameObject.FindGameObjectWithTag ("Player1");
		players [1] = GameObject.FindGameObjectWithTag ("Player2");
		players [2] = GameObject.FindGameObjectWithTag ("Player3");
		players [3] = GameObject.FindGameObjectWithTag ("Player4");
	}

	void SerchController()
	{
		var state = GamePad.GetState (GamePad.Index.One);
		//Debug.Log (state);
	}

	// Update is called once per frame
	void Update () {
		

	}

	void Move()
	{

	}
}
