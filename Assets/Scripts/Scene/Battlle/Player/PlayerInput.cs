using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerInput : SingletonMonoBehaviour<PlayerInput> {
	//最後にpublicにする
//	public GameObject[] players = new GameObject[4];

	private Dictionary<int, GamePad.Index> _inputMap
		= new Dictionary<int, GamePad.Index>();

	public List<IPlayerMove> playerMoveList 
		= new List<IPlayerMove>();

	// Use this for initialization
	void Start () {
//		SerchPlayer ();
//		SerchController ();
		Init();
	}

	public void Init()
	{
		Test ();
		var list = GameDataManager.Instance.PlayerIDList;
		for (int i = 0; i < list.Count; i++){
			_inputMap.Add (list [i], (GamePad.Index)(i + 1));
		}
	}

	void Test(){
		GameDataManager.Instance.AddPlayer (0);
		GameDataManager.Instance.AddPlayer (1);
	}

	// Update is called once per frame
	void FixedUpdate () {

		// 入力受付
		for(int i=0;i<_inputMap.Count;i++){
			if(GamePad.GetButtonDown(GamePad.Button.A, _inputMap[i])){
				Debug.Log(i+ "push A button");
			}
			// IDから情報取得
			GamepadState state = GamePad.GetState (_inputMap[i]);
			Debug.Log(state.LeftStickAxis);
			Debug.Log (playerMoveList [i]);
			playerMoveList [i].Move (state.LeftStickAxis);
		}
	}
}
