using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.localPosition.z < 3) {
			this.transform.localPosition += Vector3.forward * 3 * Time.deltaTime;
		}
	}
}
