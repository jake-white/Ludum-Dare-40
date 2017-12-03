using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	private bool caught = false, frozen = false;
	public GameObject mainCam;
	public GameObject player;
	public Score scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Animator camAnim = mainCam.GetComponent<Animator>();
		if(camAnim.GetCurrentAnimatorStateInfo(0).IsName("Zoom Out")) {
			resetGameState();
		}
	}

	public bool isCaught() {
		return caught;
	}

	public void catchPlayer() {
		caught = true;
		scoreText.clear();
		mainCam.GetComponent<Animator>().Play("Zoom In");
	}

	public bool isFrozen() {
		return frozen;
	}

	public void freezePlayer() {
		frozen = true;
	}

	public void unfreezePlayer() {
		frozen = false;
	}

	public void resetGameState() {
		GameObject[] safes = GameObject.FindGameObjectsWithTag("Safe");
		for(int i = 0; i < safes.Length; ++i) {
			safes[i].GetComponent<Safe>().reset();
		}
		player.GetComponent<PlayerScript>().respawn();
		caught = false;
	}

	public void score(int coins) {		
		scoreText.collect(coins);
	}

	public void saveScore() {
		scoreText.saveCoins();
	}

	public int getScore() {
		return scoreText.getValue();
	}
}
