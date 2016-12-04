using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public TimeManager timeManager;
	public GameObject UIManager;

	public enum BattleStatus{
		WAIT,
		START,
		END
	}

	[SerializeField]
	public BattleStatus battleStatus;

	void Start(){
		SetBattleStatus (BattleStatus.WAIT);
	}
	
	// Update is called once per frame
	void Update () {
		WatchTimer ();
		WatchRanking ();
	}

	//BattleStatusの更新
	void OnChangedStatus(BattleStatus newStatus){
		switch (newStatus) {
		case BattleStatus.WAIT:
			BattleUI.Instance.SpawnAll ();
			timeManager.InitTimer ();
			StartCoroutine (wait ());
			break;
		case BattleStatus.START:
			timeManager.StartTimer ();
			PlayerInput.Instance.canInput = true;
			break;
		case BattleStatus.END:
			timeManager.EndCount ();
			BattleUI.Instance.Finish ();
			PlayerInput.Instance.canInput = false;
			Debug.Log ("end");
			StartCoroutine (goResult ());
			break;
		}
	}

	public void SetBattleStatus(BattleStatus newStatus){
		battleStatus = newStatus;
		OnChangedStatus (battleStatus);
	}

	IEnumerator wait(){
		yield return new WaitForSeconds (1f);
		UIManager.GetComponent<BattleUI> ().setCountDown (3);
		yield return new WaitForSeconds (1f);
		UIManager.GetComponent<BattleUI> ().setCountDown (2);
		yield return new WaitForSeconds (1f);
		UIManager.GetComponent<BattleUI> ().setCountDown (1);
		yield return new WaitForSeconds (1f);
		UIManager.GetComponent<BattleUI> ().setCountDown (0);
		SetBattleStatus (BattleStatus.START);
	}

	IEnumerator goResult(){
		yield return new WaitForSeconds (1f);
		BattleUI.Instance.Result ();
	}

	//時間切れだったらゲーム終了
	void WatchTimer(){
		if (timeManager.time <= 0 && battleStatus  != BattleStatus.END) {
			SetBattleStatus (BattleStatus.END);
		}
	}

	//プレイヤーが残り一人じゃないかどうかcheck
	void WatchRanking(){
		if (ScoreManager.Instance.top == GameDataManager.Instance.PlayerIDList.Count - 1) {
			SetBattleStatus (BattleStatus.END);
		}
	}

}
