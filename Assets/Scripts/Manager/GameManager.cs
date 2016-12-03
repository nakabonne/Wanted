using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject TimeManager;
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
	}

	//BattleStatusの更新
	void OnChangedStatus(BattleStatus newStatus){
		switch (newStatus) {
		case BattleStatus.WAIT:
			BattleUI.Instance.SpawnAll ();
			TimeManager.GetComponent<TimeManager> ().InitTimer ();
			StartCoroutine (wait ());
			break;
		case BattleStatus.START:
			TimeManager.GetComponent<TimeManager>().StartTimer();
			break;
		case BattleStatus.END:
			TimeManager.GetComponent<TimeManager> ().EndCount ();
			Debug.Log ("end");
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

	void WatchTimer(){
		if (TimeManager.GetComponent<TimeManager> ().time <= 0 && battleStatus  != BattleStatus.END) {
			SetBattleStatus (BattleStatus.END);
		}
	}

}
