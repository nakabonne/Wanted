using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

	public GameObject beamObject;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			BeamFire();
		}
		
	}

	void BeamFire(){
		Instantiate (beamObject ,new Vector3(this.transform.position.x,0.5f,this.transform.position.z),Quaternion.identity);
	}
}
