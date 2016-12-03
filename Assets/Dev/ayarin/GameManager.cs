using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	enum BattleStatus{
		WAIT,
		START,
		END
	}

	[SerializeField]
	BattleStatus battleStatus;
	
	// Update is called once per frame
	void Update () {
		
	}

	//BattleStatusの更新
	void OnChangedStatus(BattleStatus newStatus){
		switch (newStatus) {
		case BattleStatus.WAIT:
			break;
		case BattleStatus.START:
			break;
		case BattleStatus.END:
			break;
		}
	}

	public void SetBattleStatus(BattleStatus newStatus){
		battleStatus = newStatus;
		OnChangedStatus (battleStatus);
	}



}
