using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {

	private Animator _animator;
	public Animator CachedAnimator{
		get{ return _animator ?? (_animator = this.GetComponent<Animator>());}
	}

	private PlayerModel _model;

	void Start(){
		_model = this.GetComponent<PlayerModel> ();
		PlayerInput.Instance.playerViewMap.Add (_model.PlayerID, this);
	}

	public void StartRun(){
		CachedAnimator.SetBool ("isRun", true);
	}

	public void StopRun(){
		CachedAnimator.SetBool ("isRun", false);
	}
}
