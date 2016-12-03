using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UniRx;

public class PlayerInput : SingletonMonoBehaviour<PlayerInput> {
	//最後にpublicにする
//	public GameObject[] players = new GameObject[4];

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
		ObservableGamePadInput.Instance.OnButtonADownAsObservable
			.Subscribe (x => Debug.Log (x + "push A button"));
	}

	void Test(){
		GameDataManager.Instance.AddPlayer (1);
		GameDataManager.Instance.AddPlayer (2);
	}

	// Update is called once per frame
	void FixedUpdate () {

		// 入力受付
		for(int i=0;i<GameDataManager.Instance.PlayerIDList.Count;i++){
			GamePad.Index index = (GamePad.Index)(i+1);
		
			// IDから情報取得
			GamepadState state = GamePad.GetState (index);
			playerMoveList [i].Move (state.LeftStickAxis);
		}
	}
}
