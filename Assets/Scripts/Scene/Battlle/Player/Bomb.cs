using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public float stayTime = 1.0f;

	public GameObject[] explosions = new GameObject[4];

	Exposion exposion;
	// Use this for initialization
	void Start () {
		StartCoroutine(PutExplosion (""));
		//SearchWall ();
		//数秒後に爆発
		//Invoke ("Explosion", stayTime);
	
		
	}

	//障害物があるかどうかをチェック
	/*void SearchWall()
	{
		//Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
		Ray rayup = new Ray(transform.position, new Vector3 (0, 0, 1));
		Ray raydown = new Ray(transform.position, new Vector3 (0, 0, -1));
		Ray rayleft = new Ray(transform.position, new Vector3 (-1, 0, 0));
		Ray rayright = new Ray(transform.position, new Vector3 (1, 0, 0));

		//Rayが当たったオブジェクトの情報を入れる箱
		RaycastHit hitInfoUp;
		RaycastHit hitInfoDown;
		RaycastHit hitInfoLeft;
		RaycastHit hitInfoRight;

		//Rayの飛ばせる距離
		int distance = 3;

		//Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
		Debug.DrawLine (rayup.origin, this.transform.position + new Vector3 (1,0,0) * distance, Color.red);
		Debug.DrawLine (raydown.origin, this.transform.position + new Vector3 (-1,0,0) * distance, Color.red);
		Debug.DrawLine (rayleft.origin, this.transform.position + new Vector3 (0,0,1) * distance, Color.red);
		Debug.DrawLine (rayup.origin, this.transform.position + new Vector3 (0,0,-1) * distance, Color.red);

		//もしRayにオブジェクトが衝突したら（Ray別に処理を分けてる）
		//                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
		if (Physics.Raycast(rayup,out hitInfoUp,distance))
		{
			if (hitInfoUp.collider.tag == "Wall") {
				Debug.Log ("前");
				StartCoroutine (PutExplosion ("前"));
			}
		}

		if (Physics.Raycast(raydown,out hitInfoDown,distance))
		{
			if (hitInfoDown.collider.tag == "Wall") {
				Debug.Log ("下");
				StartCoroutine (PutExplosion ("下"));
			}
		}

		if (Physics.Raycast(rayleft,out hitInfoLeft,distance))
		{
			if (hitInfoLeft.collider.tag == "Wall") {
				Debug.Log ("左");
				StartCoroutine (PutExplosion ("左"));
			}
		}

		if (Physics.Raycast (rayright, out hitInfoRight, distance)) {
			if (hitInfoRight.collider.tag == "Wall") {
				Debug.Log ("右");
				StartCoroutine (PutExplosion ("右"));
			}
		} else {
			StartCoroutine (PutExplosion (" "));
		}
	}*/
		
	//エフェクト生成
	IEnumerator PutExplosion(string Walldirection){
		yield return new WaitForSeconds(3.0f);
		//四方向に生成
		//上
		GameObject exp = Instantiate (explosions[0], transform.position + transform.forward, Quaternion.identity) as GameObject;
		exp.GetComponent<Exposion> ().bomb = this.transform.position;
		//下
		exp = Instantiate (explosions[1], transform.position - transform.forward, Quaternion.identity) as GameObject;
		exp.GetComponent<Exposion> ().bomb = this.transform.position;
		//左
		exp = Instantiate (explosions[2], transform.position - transform.right , Quaternion.identity) as GameObject;
		exp.GetComponent<Exposion> ().bomb = this.transform.position;
		//右
		exp = Instantiate (explosions[3], transform.position + transform.right, Quaternion.identity) as GameObject;
		exp.GetComponent<Exposion> ().bomb = this.transform.position;
		//爆風範囲内に障害物があった場合、その方向にあるexplosionの大きさを調整
		switch (Walldirection) 
		{
		case "前":
			Debug.Log ("前のを小さくしたよ");
			explosions [0].transform.localScale = new Vector3 (2.0f, 3.0f, 0.5f);
			break;
		case "下":
			explosions [1].transform.localScale -= new Vector3 (0, 0, -1);
			break;
		case "左":
			explosions [2].transform.localScale -= new Vector3 (1, 0, 0);
			break;
		case "右":
			explosions [0].transform.localScale -= new Vector3 (-1, 0, 0);
			break;
		}
		Destroy (gameObject);

//		//四方にエフェクトを生成
//		for(int i=0; i<4; i++)
//		{
//			if (Walldirection == "前" && i == 0) {
//				Debug.Log ("前だよ");
//				//exposion.ScaleChange ("前");
//				//GameObject up = explosion;
//				//up.transform.localScale -= Vector3.forward;
//				//explosion.transform.localScale -= Vector3.forward;
//			}
//			if (Walldirection == "右" && i == 1) {
//				Debug.Log ("右だよ");
//				//exposion.ScaleChange ("右");
//				//GameObject right = explosion;
//				//explosion.transform.localScale -= Vector3.right;
//			}
//			if (Walldirection == "下" && i == 2) {
//				Debug.Log ("下だよ");
//				//exposion.ScaleChange ("下");
//				//GameObject up = explosion;
//				//GameObject down = explosion;
//				//explosion.transform.localScale -= new Vector3 (0,0,-1);
//			}
//			if (Walldirection == "左" && i == 3) {
//				Debug.Log ("左だよ");
//				//exposion.ScaleChange ("左");
//				//GameObject left = explosion;
//				//explosion.transform.localScale -= new Vector3 (-1, 0, 0);
//			}
//			Instantiate (explosion,transform.forward,Quaternion.identity);
//			transform.Rotate(new Vector3(0, 1, 0), 90);
//		}
	}



}
