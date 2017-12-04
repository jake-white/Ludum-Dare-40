﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour {
	protected GameObject player;
	public GameState state;
	public GameObject viewCircle;
	private int viewRadius = 30;
	private bool sighted = true;
	private bool target = false, soundTarget = false;
	// Use this for initialization
	void Start () {
		customStart();
		player = GameObject.Find("Player");
		state = GameObject.Find("GameState").GetComponent<GameState>();
	}

	public virtual void customStart () {}
	
	// Update is called once per frame
	public void sight () {
		int layerMask = 1 << 0; //only targeting layer 0
		RaycastHit2D outOfSight = Physics2D.Linecast(transform.position, player.transform.position, layerMask);
		bool playerInSight = outOfSight.collider == player.GetComponent<Collider2D>();
		if((target && playerInSight) || soundTarget) {
			state.catchPlayer();
			if(state.isCaught()) {
				GetComponent<AudioSource>().Play();
			}
			loseTarget();
			loseSoundTarget();
		} 
		else {

		}
	}

	public void setTarget() {
		target = true;
	}

	public void loseTarget() {
		target = false;
	}

	public void setSoundTarget() {
		soundTarget = true;
	}

	public void loseSoundTarget() {
		soundTarget = false;
	}
}
