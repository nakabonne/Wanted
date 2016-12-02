using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorCreate : MonoBehaviour {

	public GameObject floorCube;

	public void CreateFloor(){
		
		int x, z;
		GameObject clone;
		GameObject floorParent = new GameObject ("Floor");

		for (x = 0; x < floorManager.n ; x++) {
			for (z = 0; z < floorManager.n ; z++) {
				clone = Instantiate (floorCube, new Vector3 (x, 0, z), Quaternion.identity);
				clone.transform.parent = floorParent.transform;
				floorManager.floorCube [x,z] = clone;
			}
		}

	}
}
