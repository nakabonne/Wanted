﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			MySceneManager.GoToCharaSelect ();
		}
	}
}
