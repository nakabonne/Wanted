using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour {

	void Start(){
		AudioManager.Instance.PlayBGM (BGMKey.MAINBGM);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			MySceneManager.GoToCharaSelect ();
		}
	}
}
