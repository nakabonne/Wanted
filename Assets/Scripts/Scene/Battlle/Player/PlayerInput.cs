using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UniRx;

public class PlayerInput : SingletonMonoBehaviour<PlayerInput> {
	

	public Dictionary<int, IPlayerMove> playerMoveMap 
	= new Dictionary<int, IPlayerMove>();

	public Dictionary<int, IPlayerAttack> playerAttackMap
		= new Dictionary<int, IPlayerAttack>();

	public bool canInput = false;


	// Use this for initialization
	void Start () {
		Init();
	}

	public void Init()
	{
		ObservableGamePadInput.Instance.OnButtonADownAsObservable
			.Where(_=>canInput)
			.Subscribe (x => playerAttackMap[x].PutBeam())
			.AddTo (this.gameObject);

		ObservableGamePadInput.Instance.OnButtonYDownAsObservable
			.Where(_=>canInput)
			.Subscribe (x => playerAttackMap [x].PutBomb ())
			.AddTo (this.gameObject);
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (!canInput)
			return;


		// 入力受付
		for(int i=0;i<GameDataManager.Instance.PlayerIDList.Count;i++){
			GamePad.Index index = (GamePad.Index)(i+1);
		
			// IDから情報取得
			GamepadState state = GamePad.GetState (index);
			playerMoveMap [i+1].Move (state.LeftStickAxis);
		}
	}
}
