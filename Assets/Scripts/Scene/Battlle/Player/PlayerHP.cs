using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {

	public GameObject[] hpImage = new GameObject[5];
	PlayerModel playerModel;
	private int stock = 5;
	
	// Update is called once per frame
	void Start () {
		playerModel = this.gameObject.GetComponent<PlayerModel> ();
	}

	void Updata(){
		ShowHP ();
	}

	void ShowHP(){
		if(stock != playerModel.stock){
			stock = playerModel.stock;
			hpImage [stock - 1].SetActive (false);
		}
	}
			
				
}
