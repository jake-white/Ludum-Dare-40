using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour {
	private bool opened = false;
	public int value = 1;
	public GameObject coin;
	private GameState state;

	// Use this for initialization
	void Start () {
		state = GameObject.Find("GameState").GetComponent<GameState>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void open() {
		opened = true;
		GameObject coinAnimation = Instantiate(coin, transform.position, Quaternion.identity);
		coinAnimation.transform.SetParent(gameObject.transform);
		Vector3 coinPosition = transform.position;
		coinPosition.y += 1.5f;
		coinAnimation.transform.position = coinPosition;
	}

	public bool isOpened() {
		return opened;
	}

	public int getValue() {
		return value;
	}

	public void reset() {
		opened = false;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.GetComponent<PlayerScript>() != null && !this.isOpened()) {
			this.open();
			int coins = this.getValue();
			state.score(coins);
		}
	}
}
