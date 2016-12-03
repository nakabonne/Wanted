using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : SingletonMonoBehaviour<MySceneManager> {

	public static void GoToTitle(){
		SceneManager.LoadScene ("Title");
	}

	public static void GoToCharaSelect(){
		SceneManager.LoadScene ("CharaSelect");
	}

	public static void GoToMainGame(){
		SceneManager.LoadScene ("MainGame");
	}

	public static void GoToResult(){
		SceneManager.LoadScene ("Result");
	}
}
