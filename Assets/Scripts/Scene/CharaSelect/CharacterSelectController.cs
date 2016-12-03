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
		ObservableGamePadInput.Instance.OnButtonADownAsObservable
			.Where(x=>IsNewController(x))
			.Subscribe (x => _model.AddPlayer(x))
			.AddTo (this.gameObject);

		ObservableGamePadInput.Instance.OnStartButtonDownAsObservable
			.Where (x => x == 1)
			.Where (x => _model.PlayerCount > 1)
			.Subscribe (_ => {
				_model.SavePlayerIDList();
				MySceneManager.GoToMainGame ();
			});
	}

	// 新規コントローラーか確かめる
	bool IsNewController(int playerID){
		return !_model.IsExistPlayer (playerID);
	}
}
