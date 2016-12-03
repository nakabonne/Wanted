using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum SEKey
{
	Beam,
	Explosion,
	PutBomb
//	Button1,
//	Attack1,
}

public enum BGMKey
{
	MAINBGM
//	Title,
//	Select,
//	Battle,
//	Result
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : SingletonMonoBehaviour<AudioManager> {

	// SEKey, パスのマップ
	private Dictionary<SEKey, string> _SE_PathMap =
		new Dictionary<SEKey, string>
	{
		{SEKey.Beam, "Beam" },
		{SEKey.Explosion, "Explosion" },
		{SEKey.PutBomb, "PutBomb" }
//		{ SEKey.Button1, "Button/se_button1" },
//		{ SEKey.Attack1, "se_Attack1" },
//		{ SEKey.CorrectAnswer, "se_CorrectAnswer" },
//		{ SEKey.GameOver, "se_GameOver" },
//		{ SEKey.QCount, "se_QCount" },
//		{ SEKey.Spawn, "se_Spawn" },
//		{ SEKey.StageClear, "se_StageClear" },
//		{ SEKey.WrongAnswer, "se_WrongAnswer" },
	};

	// SEKeyで音を取得
	private Dictionary<SEKey, AudioClip> _SE_Map
	= new Dictionary<SEKey, AudioClip>();

	// BGMKey, パスのマップ
	private Dictionary<BGMKey, string> _BGM_PathMap =
		new Dictionary<BGMKey, string>
	{
		{BGMKey.MAINBGM, "MAINBGM"}
//		{ BGMKey.Title, "bgm_Title_town" },
//		{ BGMKey.Battle, "bgm_Battle_New_Morning" },
//		{ BGMKey.Select, "bgm_Select_none" },
//		{ BGMKey.Result, "bgm_Result_MagicalForest" }

	};

	// BGMKeyで音を取得
	private Dictionary<BGMKey, AudioClip> _BGM_Map
	= new Dictionary<BGMKey, AudioClip>();

	private AudioSource _bgmSource;

	private List<AudioSource> _seSource = new List<AudioSource>();

	protected override void Awake ()
	{
		base.Awake ();
		_bgmSource = this.GetComponent<AudioSource> ();
	}


	/// <summary>
	/// SEを再生
	/// </summary>
	/// <param name="key">Key.</param>
	public void PlaySE(SEKey key){
		if (!_SE_Map.ContainsKey (key)) {
			_SE_Map.Add (key, ResourcesManager.Instance.GetSE (_SE_PathMap [key]));
		}

		AudioSource source = _seSource.Where (x => !x.isPlaying).FirstOrDefault ();
		if (!source) {
			source = this.gameObject.AddComponent<AudioSource> ();
			_seSource.Add (source);
		}
		source.clip = _SE_Map [key];
		source.Play();
	}


	/// <summary>
	/// BGMを再生
	/// </summary>
	/// <param name="key">Key.</param>
	public void PlayBGM(BGMKey key){
		if (!_BGM_Map.ContainsKey (key)) {
			_BGM_Map.Add (key, ResourcesManager.Instance.GetBGM (_BGM_PathMap [key]));
		}
		_bgmSource.clip = _BGM_Map [key];
		_bgmSource.Play ();
	}

}
