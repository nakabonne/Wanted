using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectManager : SingletonMonoBehaviour<EffectManager> {

	public float scale = 1.0f;

	// SEKey, パスのマップ
	private Dictionary<EffectType, string> _effect_PathMap =
		new Dictionary<EffectType, string>
	{
		{ EffectType.Spawn, "Eff_Spawn_1" }
	};

	private Dictionary<EffectType, GameObject> _effect_Map =
		new Dictionary<EffectType, GameObject>();

	/// <summary>
	/// エフェクトをInstantiate
	/// </summary>
	/// <param name="type">Type.</param>
	/// <param name="pos">Position.</param>
	public GameObject Spawn(EffectType type, Vector3 pos)
	{
		return Spawn (type, pos, Quaternion.identity);
	}

	public GameObject Spawn(EffectType type, Vector3 pos, Quaternion rot)
	{
		GameObject eff;
		if (!_effect_Map.ContainsKey(type)) {
			_effect_Map.Add (type, ResourcesManager.Instance.GetEffect (_effect_PathMap [type]));
		}
		eff = Instantiate(_effect_Map[type], pos, rot) as GameObject;
		eff.transform.localScale = Vector3.one * scale;
		return eff;
	}
}
