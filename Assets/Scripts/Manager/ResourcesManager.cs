using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesManager : SingletonMonoBehaviour<ResourcesManager> {


//	public readonly string hpBarPath = "Prefabs/UI/HPBar";
//	private GameObject _hpBar;
//	public GameObject HPBar{
//		get{
//			return _hpBar ??( _hpBar = LoadAsset<GameObject> (hpBarPath));
//		}
//	}
//

	public readonly string modelFolderPath = "Prefabs/Model/";

	// Resourcesフォルダから指定したPathのAssetをロード
	T LoadAsset<T>(string path) where T : Object
	{
		T asset = Resources.Load<T> (path);
		if (!asset) {
			Debug.LogError (path + "が取得できませんでした");
		}
		return asset;
	}




	/// <summary>
	/// Resourcesからキャラクターのプレハブを取得
	/// </summary>
	/// <returns>The model.</returns>
	/// <param name="charaID">Chara I.</param>
	public GameObject GetModel(string charaID){
		GameObject targetModel;
		string modelPath = modelFolderPath + charaID;
		targetModel = LoadAsset<GameObject> (modelPath);
		return targetModel;
	}

	public AudioClip GetBGM(string path){
		string audioPath = string.Format ("Audio/BGM/{0}", path);
		AudioClip audio = GetAudio(audioPath);
		return audio;
	}

	public AudioClip GetSE(string path){
		string audioPath = string.Format ("Audio/SE/{0}", path);
		AudioClip audio = GetAudio(audioPath);
		return audio;
	}
		
	AudioClip GetAudio(string path){
		AudioClip audio;
		audio = LoadAsset<AudioClip> (path);
		return audio;
	}

	// Resourcesフォルダからエフェクトを取得
	public GameObject GetEffect(string fileName){
		GameObject go = LoadAsset<GameObject> ("Prefabs/Effects/" + fileName);
		return go;
	}
}
