using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exposion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1.0f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//障害物があったらスケールを変化
	public void ScaleChange(string direction)
	{
		if (direction == "上") {
			transform.localScale -= new Vector3 (0, 0, 1);
		} 
	}
	//衝突処理
	void OnTriggerEnter(Collider collider)
	{
		collider.gameObject.SendMessage ("ReceiveBlast");
//		//プレイヤーに当たったら吹っ飛ばす
//		if (collider.tag == "Player1" || collider.tag == "Player2" || collider.tag == "Player3" || collider.tag == "Player4") {
//			PlayerMove playerMove = collider.gameObject.GetComponent<PlayerMove> ();
//			playerMove.ReceiveBlast ();
//		}
			
	}


}
