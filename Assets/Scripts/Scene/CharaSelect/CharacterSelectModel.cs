using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CharacterSelectModel : MonoBehaviour {


	// コントローラー
//	private CharacterSelectController _control;

	// 参加者リスト
	private ReactiveCollection<int> _playerIDList = 
		new ReactiveCollection<int>();

	public int PlayerCount{
		get{ return _playerIDList.Count; }
	}
	
	public IObservable<CollectionAddEvent<int>> OnAddPlayerIDList{
		get{ return _playerIDList.ObserveAdd (); }
	}

	// 初期化
	public void Init(){
//		_control = CharacterSelectController.Instance;
	}

	/// <summary>
	/// 参加
	/// </summary>
	public void AddPlayer(int playerID){
		_playerIDList.Add (playerID);
	}

	/// <summary>
	/// 除名
	/// </summary>
	public void RemovePlayer(int playerID){
		_playerIDList.Remove (playerID);
	}

	// すでにいるプレイヤーか確かめる
	public bool IsExistPlayer(int playerID){
		return _playerIDList.Contains (playerID);
	}

	public void SavePlayerIDList(){
		List<int> idList = new List<int> ();
		foreach (var item in _playerIDList) {
			idList.Add (item);
		}

		GameDataManager.Instance.SetPlayerIDList (idList);
	}
}
