using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using GamepadInput;

public class CharacterSelectController : SingletonMonoBehaviour<CharacterSelectController> {

	[SerializeField]
	private CharacterSelectView _view;

	[SerializeField]
	private CharacterSelectModel _model;

	protected override void Awake ()
	{
		base.Awake ();
		Init ();
	}

	public void Init(){
		_view = this.GetComponent<CharacterSelectView> ();
		_model = this.GetComponent<CharacterSelectModel> ();
		_model.Init ();

		_model.OnAddPlayerIDList
			.Select (x => x.Value)
			.Subscribe (val => _view.ShowPlayer (val));
	}

	void Start(){
		ObservableGamePadInput.Instance.OnStartButtonDownAsObservable
			.Subscribe (x => Debug.Log (x))
			.AddTo (this.gameObject);

//		this.UpdateAsObservable()
//			.Where(_=>
//				GamePad.GetButtonDown(GamePad.Button.Start,GamePad.Index.Any))
//			.Where(x=>)
	}

	bool GetNewController(){
		
//		if(GamePad.GetButtonDown(GamePad.Button.Start,GamePad.Index.Any))
		return false;
	}




}
