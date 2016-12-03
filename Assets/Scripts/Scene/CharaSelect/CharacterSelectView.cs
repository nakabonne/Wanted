using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectView : MonoBehaviour {

	[SerializeField]
	private Transform[] showPos;

	// プレイヤーを表示
	public void ShowPlayer(int playerID){
		string charaName = string.Empty;
		switch (playerID) {
		case 1:
			charaName = "Utc";
			break;
		case 2:
			charaName = "Misaki";
			break;
		case 3:
			charaName = "Yuko";
			break;
		case 4:
			// 4体目のプレハブを呼ぶ
			break;
		
		}
		// リソースからプレハブ取得
		GameObject obj = ResourcesManager.Instance.GetModel(charaName);
		// 生成
		GameObject chara = Instantiate (obj, showPos [playerID-1].position, showPos[playerID-1].rotation) as GameObject;
		// スケール調節
		chara.transform.localScale = Vector3.one * 4f;
		EffectManager.Instance.Spawn (EffectType.Spawn, showPos [playerID - 1].position);

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.A)) {
			ShowPlayer (1);
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			ShowPlayer (2);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			ShowPlayer (3);
		}
	}
}
