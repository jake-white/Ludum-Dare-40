using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private int coins = 0;
	SaveData savedata;

	// Use this for initialization
	void Start () {
		savedata =  GameObject.Find("DontDestroyBoi").GetComponent<SaveData>();
		coins = savedata.getSavedCoins();
		updateCoinText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void collect(int value) {
		coins += value;
		GetComponent<Text>().text = coins + "Coins";
		updateCoinText();
	}

	private void updateCoinText() {
		GetComponent<Text>().text = coins + " Coins";
	}

	public void saveCoins() {
		savedata.saveCoins(coins);
	}

	public int getValue() {
		return coins;
	}

	public void clear() {
		coins = savedata.getSavedCoins();
		updateCoinText();
	}
}
