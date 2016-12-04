using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;

public class BattleUI : SingletonMonoBehaviour<BattleUI> {

	public Text timer;
	public Text countDown;

	public GameObject resultCanvas;
	public GameObject mainCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer.text = TimeManager.Instance.time.ToString ("f2");
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

	//Finish文
	public void Finish(){
			countDown.text = "Finish";
			countDown.gameObject.transform.DOShakeScale (1f).OnComplete (() => {
				countDown.text = "";
			});
	}

	//Resultを表示
	public void Result(){
		resultCanvas.SetActive (true);
		mainCanvas.SetActive (false);
	}

	//Playerを生成する
	void SpawnPlayer(int playerID){
		string charaName = string.Empty;
		Vector3 pos = Vector3.zero;
		switch (playerID) {
		case 1:
			charaName = "BattleUtc";
			pos = new Vector3 (0, 1, 11);
			break;
		case 2:
			charaName = "BattleMisaki";
			pos = new Vector3 (11, 1, 11);
			break;
		case 3:
			charaName = "BattleYuko";
			pos = new Vector3 (0, 1, 0);
			break;
		case 4:
			// 4体目のプレハブを呼ぶ
			pos = new Vector3(11,1,0);
			break;

		}
		GameObject obj = ResourcesManager.Instance.GetModel(charaName);
		GameObject chara = Instantiate (obj, pos, Quaternion.Euler(new Vector3(0,180,0))) as GameObject;
		chara.transform.localScale = Vector3.one * 1f;
		chara.GetComponent<PlayerModel> ().PlayerID = playerID;
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
