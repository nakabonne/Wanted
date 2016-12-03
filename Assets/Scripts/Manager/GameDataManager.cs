using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : SingletonMonoBehaviour<GameDataManager> {

	private List<int> _playerIDList = new List<int>();
	public List<int> PlayerIDList{
		get{ return _playerIDList;}
	}

	public void SetPlayerIDList(List<int> list){
		_playerIDList = list;
	}

}
