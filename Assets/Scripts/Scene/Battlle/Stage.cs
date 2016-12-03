using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage : MonoBehaviour {

	//マス目の数
	static int n = 12;
	//ビームの有効マス
	static int b = 5;

	GameObject[,] stageCube = new GameObject[n,n];

	public GameObject stageCubePrefab;

	void Start(){
		CreateStage ();
	}

	void Update(){
	}

	//ステージ生成
	public void CreateStage(){
		GameObject clone;
		GameObject floorParent = new GameObject ("Stage");

		for (int x = 0; x < n ; x++) {
			for (int z = 0; z < n ; z++) {
				clone = Instantiate (stageCubePrefab, new Vector3 (x, -0.5f, z), Quaternion.identity);
				clone.transform.parent = floorParent.transform;
				stageCube [x,z] = clone;
			}
		}
	}

	//ビーム Beam(transform.position, transform.forward);
	public IEnumerator Beam(Vector3 position, Vector3 rotate){
		
		//stageCube [(int)position.x, (int)position.z].transform.DOMoveY (-20f, 5f);
		for (int i = 1; i < b+1; i++) {
			int x = 100, z = 100;
			yield return new WaitForSeconds (0.1f);
			if (0.9f <= rotate.z && rotate.z <= 1) {
				//forward
				x = (int)position.x + i;
				z = (int)position.z;
			} else if (0.9f <= rotate.x && rotate.x <= 1) {
				//right
				x = (int)position.x;
				z = (int)position.z - i;
			} else if (-1 <= rotate.z && rotate.y <= -0.9f) {
				//back
				x = (int)position.x - i;
				z = (int)position.z;
			} else if (-1 <= rotate.x && rotate.x <= -0.9f) {
				//left
				x = (int)position.x;
				z = (int)position.z + i;
			}
			stageCube [x, z].transform.DOMoveY (-20f, 5f).OnComplete(() => {
				//Debug.Log("おわた");
				Repop(x, z);
			});
		}
	}

	public void Repop(int x, int z){
		//Debug.Log (x + "," + z + "あがる");
		stageCube [x, z].transform.position = new Vector3 (x, -0.5f, z);
	}
}
