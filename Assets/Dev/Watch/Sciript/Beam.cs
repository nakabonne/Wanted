﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		BreakeGround ();
	}
	//地面を破壊する
	void BreakeGround()
	{
		//Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
		Ray ray = new Ray (transform.position, new Vector3 (0, -1, 0));

		//Rayが当たったオブジェクトの情報を入れる箱
		RaycastHit hit;

		//Rayの飛ばせる距離
		int distance = 10;

		//Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
		Debug.DrawLine (ray.origin, ray.direction * distance, Color.red);

		//もしRayにオブジェクトが衝突したら
		//                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
		if (Physics.Raycast(ray,out hit,distance))
		{
			//Rayが当たったオブジェクトのtagがGroundだったら
			if (hit.collider.tag == "Ground"){
				//GameObject ground = hit.collider.gameObject;
				Stage stage = hit.collider.gameObject.GetComponent<Stage> ();
				stage.Beam (transform.position, transform.forward);
			}
		}
	}
}
