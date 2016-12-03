using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UniRx;
using UniRx.Triggers;

// ゲームパッドの入力をObservable化して，入力されたゲームパッドのindexを通知
public class ObservableGamePadInput : SingletonMonoBehaviour<ObservableGamePadInput> {

	private Subject<int> _startSubject = new Subject<int>();
	public IObservable<int> OnStartButtonDownAsObservable{
		get{ return _startSubject; }
	}

	private Subject<int> _buttonASubject = new Subject<int>();
	public IObservable<int> OnButtonADownAsObservable{
		get{ return _buttonASubject; }
	}

	void Start(){
		this.UpdateAsObservable ()
			.Subscribe (_ => GetGamePadInput ());
	}


	void GetGamePadInput(){
		int i = 0;
		for(i = 1;i<5;i++){
			GamePad.Index index = (GamePad.Index)i;
			if (GamePad.GetButtonDown (GamePad.Button.Start, index)) {
				_startSubject.OnNext (i);
			}

			if (GamePad.GetButtonDown (GamePad.Button.A, index)) {
				_buttonASubject.OnNext (i);
			}
		}
	}
}
