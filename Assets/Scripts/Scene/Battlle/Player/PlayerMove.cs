using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IPlayerMove {

	public float moveSpeed = 0.1f;



	// Use this for initialization
	void Start () {
		PlayerInput.Instance.playerMoveList.Add (this);
	}


	public void Move(Vector2 dir){
		Debug.Log (IsGround ());
		//足元に地面がなかったら移動は不可
		if (IsGround ()) {
			this.transform.position += new Vector3(dir.x, 0, dir.y)  * moveSpeed;
		}
	}

	//地面があるかチェックするメソッド
	bool IsGround()
	{
		//Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
		Ray ray = new Ray (transform.position, Vector3.down);


		//Rayの飛ばせる距離
		int distance = 10;
		//Rayが当たったオブジェクトの情報を入れる箱
		RaycastHit hitInfo;
		//Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
		Debug.DrawLine (ray.origin, this.transform.position + Vector3.down * distance, Color.red);

		//もしRayにオブジェクトが衝突したら
		//                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
		if (Physics.Raycast(ray,out hitInfo,distance))
		{
			Debug.Log (hitInfo.collider.transform.parent.tag);
			if (hitInfo.collider.transform.parent.tag == "Ground") {
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
