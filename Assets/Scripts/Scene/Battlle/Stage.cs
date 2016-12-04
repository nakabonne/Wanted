using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage : SingletonMonoBehaviour<Stage> {

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

		for (int x = 0; x < n ; x++) {
			for (int z = 0; z < n ; z++) {
				clone = Instantiate (stageCubePrefab, new Vector3 (x, -0.5f, z), Quaternion.identity, this.transform);
				stageCube [x,z] = clone;
			}
		}
	}

	//ビーム Beam(transform.position, transform.forward);
	public void Beam(Vector3 position, float rotate){
		StartCoroutine(BeamCoroutine(position,rotate));
	}

	private IEnumerator BeamCoroutine(Vector3 position, float rotate){
		Debug.Log (position + ", " + rotate);
		//stageCube [(int)position.x, (int)position.z].transform.DOMoveY (-20f, 5f);
		for (int i = 1; i < b+1; i++) {
			int x = 100, z = 100;
			yield return new WaitForSeconds (0.2f);
			if (Mathf.RoundToInt(rotate) == 270) {
				//left
				x = Mathf.RoundToInt(position.x) - i;
				z = Mathf.RoundToInt(position.z);
			} else if (Mathf.RoundToInt(rotate) == 0) {
				//back
				x = Mathf.RoundToInt(position.x);
				z = Mathf.RoundToInt(position.z) + i;
			} else if (Mathf.RoundToInt(rotate) == 90) {
				//right
				x = Mathf.RoundToInt(position.x) + i;
				z = Mathf.RoundToInt(position.z);
			} else if (Mathf.RoundToInt(rotate) == 180) {
				//forward
				x = Mathf.RoundToInt(position.x);
				z = Mathf.RoundToInt(position.z) - i;
			}
			if (x >= n || z >= n || x < 0 || z < 0)	break;
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
