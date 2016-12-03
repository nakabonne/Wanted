using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;

public class BattleUI : SingletonMonoBehaviour<BattleUI> {

	public GameObject TimeManager;

	public Text timer;
	public Text countDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer.text = TimeManager.GetComponent<TimeManager> ().time.ToString ("f2");
	}

	//カウントダウンを始める
	public void setCountDown(int time){
		if (time == 0) {
			countDown.text = "START";
			countDown.gameObject.transform.DOShakeScale (1f).OnComplete(() =>{
				countDown.text = "";
			});
		} else {
			countDown.text = time.ToString ();
			countDown.gameObject.transform.DOPunchScale (new Vector3 (1f, 1f, 1f), 0.85f, 1, 0).OnComplete(() =>{
				countDown.text = "";
			});
		}
	}

	//Playerを生成する
	void SpawnPlayer(int playerID){
		string charaName = string.Empty;
		Vector3 pos = Vector3.zero;
		switch (playerID) {
		case 1:
			charaName = "Utc";
			pos = new Vector3 (0, 0, 11);
			break;
		case 2:
			charaName = "Misaki";
			pos = new Vector3 (11, 0, 11);
			break;
		case 3:
			charaName = "Yuko";
			pos = new Vector3 (0, 0, 0);
			break;
		case 4:
			// 4体目のプレハブを呼ぶ
			pos = new Vector3(11,0,0);
			break;

		}
		GameObject obj = ResourcesManager.Instance.GetModel(charaName);
		GameObject chara = Instantiate (obj, pos, Quaternion.identity) as GameObject;
		chara.transform.localScale = Vector3.one * 4f;
	}

	IEnumerator SpawnCoroutine(){
		for (int i = 1; i <= GameDataManager.Instance.PlayerIDList.Count; i++) {
			SpawnPlayer (i);
			yield return new WaitForSeconds (0.1f);
		}
	}

	public void SpawnAll(){
		StartCoroutine(SpawnCoroutine());
	}
}
