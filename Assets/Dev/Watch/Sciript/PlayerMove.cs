using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	//Rayが当たったオブジェクトの情報を入れる箱
	RaycastHit hitInfo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//足元に地面がなかったら移動は不可
		if (IsGround ()) {
			Move ();
		}
	}
	//移動を管理
	void Move()
	{
		if (Input.GetKey("up")) {
			transform.position += transform.forward * 0.1f;
		} 
		if (Input.GetKey ("down")) {
			transform.position += new Vector3 (0, 0, -1) * 0.1f;
		}

		if (Input.GetKey("right")) {
			transform.position += transform.right * 0.1f;
		}
		if (Input.GetKey ("left")) {
			transform.position += new Vector3 (-1, 0, 0) * 0.1f;
		}
	}
	//地面があるかチェックするメソッド
	bool IsGround()
	{
		//Rayの終着点
		//Vector3 RayEndPoint = new Vector3(this.transform.position.x, this.transform.position.y - 5, this.transform.position.z);
		Vector3 RayEndPoint = this.transform.position + Vector3.down * 5f;
		//Debug.Log (RayEndPoint);

		//Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
		Ray ray = new Ray (transform.position, Vector3.down);


		//Rayの飛ばせる距離
		int distance = 10;

		//Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
		Debug.DrawLine (ray.origin, this.transform.position + Vector3.down * distance, Color.red);

		//もしRayにオブジェクトが衝突したら
		//                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
		if (Physics.Raycast(ray,out hitInfo,distance))
		{
			if (hitInfo.collider.tag == "Ground") {
				return true;
			}


		}
		return false;
	}
	//落ちているかどうか
//	bool isDrop()
//	{
//		return hitInfo.collider.tag == "DeathZone";
//	}
}
