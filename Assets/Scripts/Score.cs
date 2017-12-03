using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private int coins = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void collect(int value) {
		coins += value;
		GetComponent<Text>().text = coins + "Coins";
	}

	public int getValue() {
		return coins;
	}
}
