using UnityEngine;
using System.Collections;

public class EffectBehaviour : MonoBehaviour {

	public float lifetime = 1;

	[System.Serializable]
	public class ControlEffect {
		public ParticleSystem system;
		public float lifetime;
	}

	public ControlEffect[] stopEffects;

	void Start () {
		for (int i = 0; i < stopEffects.Length; i++) {
			StartCoroutine (StopTimer (stopEffects [i].system, stopEffects [i].lifetime));
		}
		Destroy (this.gameObject, lifetime);
	}

	public IEnumerator StopTimer(ParticleSystem system, float time){
		yield return new WaitForSeconds (time);
		system.Stop ();
	}


	

}
