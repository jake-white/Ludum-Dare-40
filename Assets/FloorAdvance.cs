 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorAdvance : MonoBehaviour {
	private bool inProgress = false;
	public GameState state;
	public int nextFloor = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.GetComponent<PlayerScript>() != null) {
			GetComponent<AudioSource>().Play();
			state.freezePlayer();
			Invoke("LoadNextFloor", 2);
		}
	}

	void LoadNextFloor() {
		SceneManager.LoadScene("Floor " + nextFloor);
	}
}
