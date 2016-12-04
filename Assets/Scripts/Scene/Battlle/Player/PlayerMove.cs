using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour, IPlayerMove {

	public float moveSpeed = 0.05f;
	private Vector2 rotate;

	private PlayerModel _model;

	bool isStock = true;

	bool isRanked = false;

	PlayerModel playerModel;

	Vector3 startPos;

	Vector3 startPosBlockPos;
	// Use this for initialization
	void Start () {
		_model = this.GetComponent<PlayerModel> ();
		PlayerInput.Instance.playerMoveMap.Add (_model.PlayerID, this);
		//最初のポジションを保存
		Invoke("SaveStartPos",2.0f);
		playerModel = GetComponent<PlayerModel> ();

		//スタートポジションの下にあるブロックの初期位置を保存
		startPosBlockPos = StartPosBlock().transform.position; 


	}

	void Update(){
		if (isRanked = false) {
		}
	}
	//
	void SendHP()
	{
		PlayerHPManager.Instance.playerHp[0] = playerModel.stock;
		//PlayerHPManager.Instance.playerHp [0] = playerModel.stock;
	}

	//スタートポジションのブロックを返す
	GameObject StartPosBlock()
	{
		return Stage.Instance.stageCube [Mathf.FloorToInt(startPos.x),Mathf.FloorToInt(startPos.z)];
	}

	//最初のポジションを保存
	void SaveStartPos()
	{
		startPos = transform.position;
	}

	public void Move(Vector2 dir){
		if (rotate != dir) {
			rotate = dir;
			if (rotate == Vector2.down) {
				this.transform.eulerAngles = new Vector3 (0, 180, 0);
			} else if (rotate == Vector2.up) {
				this.transform.eulerAngles = new Vector3 (0, 0, 0);
			} else if (rotate == Vector2.right) {
				this.transform.eulerAngles = new Vector3 (0, 90, 0);
			} else if (rotate == Vector2.left){
				this.transform.eulerAngles = new Vector3 (0, 270, 0);
			}
		}

		//足元に地面がなかったら移動は不可
		if (IsGround ()) {
			this.transform.position += new Vector3(dir.x, 0, dir.y)  * moveSpeed;
		}
	}

	//地面があるかチェックするメソッド
	bool IsGround()
	{
		//落ちた時の処理
		if (this.transform.position.y <= -0.5f && isStock) {

			//ストックを減らす
			CutBackStock ();
			isStock = false;
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
		playerModel.stock--;
		PlayerHPManager.Instance.ShowHP(playerModel.PlayerID,playerModel.stock);
		//復活させる
		Invoke ("Return", 1.5f);
	}

	//復活する
	void Return()
	{
		//ストックが0になったらSetRankingを実行し、このオブジェクトを非表示にする
		if (playerModel.stock <= 0) {
			ScoreManager.Instance.SetRanking (playerModel.PlayerID);
			isRanked = true;
			gameObject.SetActive (false);
			return;
		}

		//スタート時に足元にあったブロックがない場合は生成位置をランダムに
		if (StartBlockIsWrongPos ()) {
			RandomRespawn ();
			//地面がない限りランダムにリスポーンを続ける
			while(IsNoGround()){
				RandomRespawn ();
			}
		} else {
			//位置を戻す
			transform.position = startPos;
			this.transform.eulerAngles = new Vector3 (0, 180, 0);
		}
		isStock = true;
	}

	//足元にブロックがない場合trueを返す
	bool IsNoGround()
	{
		return Stage.Instance.stageCube [Mathf.FloorToInt (transform.position.x), Mathf.FloorToInt (transform.position.z)].transform.position != new Vector3 (transform.position.x, -0.5f, transform.position.z);
	}
	//ランダム生成の位置
	Vector3 RandomRespawnPos()
	{
		return new Vector3 (Random.Range (0, 12), startPos.y, Random.Range (0, 12));
	}
	//ランダムに生成する
	void RandomRespawn()
	{
		transform.position = RandomRespawnPos ();
		this.transform.eulerAngles = new Vector3 (0, 180, 0);
	}
	//爆風を受けた時の処理
	public void ReceiveBlast(Vector3 pos)
	{
		Vector3 move;
		move = (this.transform.position - new Vector3 (pos.x, 0, pos.z)) * 2;
		if (move.x < 0.5f) {
			move.x *= 3;
		}
		if (move.z < 0.5f) {
			move.z *= 3;
		}
		transform.DOLocalMove (this.transform.position + move, 1f);
	}

	//スタート時に足元にあるブロックが元の位置にない（落ちてしまっている時）trueを返す
	bool StartBlockIsWrongPos()
	{
		return StartPosBlock ().transform.position != startPosBlockPos;
	}

	//落ちているかどうか
//	bool isDrop()
//	{
//		return hitInfo.collider.tag == "DeathZone";
//	}
}
