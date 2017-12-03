using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	private bool caught = false;
	public GameObject mainCam;
	public GameObject player;

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
		mainCam.GetComponent<Animator>().Play("Zoom In");
	}

	public void resetGameState() {
		player.GetComponent<PlayerScript>().respawn();
		caught = false;
	}
}
