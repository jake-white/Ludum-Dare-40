using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

	private int floorCheckpoint = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void saveCoins(int coins) {
		floorCheckpoint = coins;
	}

	public int getSavedCoins() {
		return floorCheckpoint;
	}

	public void clearCoins() {
		floorCheckpoint = 0;
	}
}
