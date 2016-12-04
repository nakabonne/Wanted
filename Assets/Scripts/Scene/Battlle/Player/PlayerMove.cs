using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour, IPlayerMove {

	public float moveSpeed = 0.1f;

	private PlayerModel _model;

	Vector3 startPos;
	// Use this for initialization
	void Start () {
		_model = this.GetComponent<PlayerModel> ();
		PlayerInput.Instance.playerMoveMap.Add (_model.PlayerID, this);
		//最初のポジションを保存
		Invoke("SaveStartPos",2.0f);

	}
	//最初のポジションを保存
	void SaveStartPos()
	{
		startPos = transform.position;
	}

	public void Move(Vector2 dir){
		//足元に地面がなかったら移動は不可
		if (IsGround ()) {
			this.transform.position += new Vector3(dir.x, 0, dir.y)  * moveSpeed;
		}
	}

	//地面があるかチェックするメソッド
	bool IsGround()
	{
		if (this.transform.position.y <= 0) {
			//ストックを減らす
			CutBackStock ();
			return false;
		}
		return true;
//		//以下はRayを使った場合の処理
//		//Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
//		Ray ray = new Ray (transform.position, Vector3.down);
//
//
//		//Rayの飛ばせる距離
//		int distance = 10;
//		//Rayが当たったオブジェクトの情報を入れる箱
//		RaycastHit hitInfo;
//		//Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
//		Debug.DrawLine (ray.origin, this.transform.position + Vector3.down * distance, Color.red);
//
//		//もしRayにオブジェクトが衝突したら
//		//                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
//		if (Physics.Raycast(ray,out hitInfo,distance))
//		{
//			//足元が地面なら
//			if (hitInfo.collider.transform.parent.tag == "Ground") {
//				return true;
//			} else {
//				CutBackStock ();
//			}
//		}
//		return false;
	}

	//ストックを減らす
	void CutBackStock()
	{
		PlayerModel playerModel = GetComponent<PlayerModel> ();
		playerModel.stock--;
		//復活させる
		Invoke ("Return", 1.5f);
	}

	//復活する
	void Return()
	{
		//位置を戻す
		transform.position = startPos;
	}

	//爆風を受けた時の処理
	public void ReceiveBlast()
	{
		transform.DOLocalMove (new Vector3 (3f, 2, 0), 2f).SetEase (Ease.InOutQuart);
	}
	//落ちているかどうか
//	bool isDrop()
//	{
//		return hitInfo.collider.tag == "DeathZone";
//	}
}
