using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CharacterSelectModel : MonoBehaviour {


	// コントローラー
	private CharacterSelectController _control;

	// 参加者リスト
	private ReactiveCollection<int> _playerIDList = 
		new ReactiveCollection<int>();
	
	public IObservable<CollectionAddEvent<int>> OnAddPlayerIDList{
		get{ return _playerIDList.ObserveAdd (); }
	}

	// 初期化
	public void Init(){
		_control = CharacterSelectController.Instance;
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
}
