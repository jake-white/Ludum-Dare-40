using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLighting : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		int layerMask = 1 << 0; //only targeting layer 0
		RaycastHit2D outOfSight = Physics2D.Linecast(transform.position, player.transform.position, layerMask);
		bool playerInSight = outOfSight.collider == player.GetComponent<Collider2D>();
		if(playerInSight) {
			GetComponent<SpriteRenderer>().color = new Color(255,255,255);
		}
		else {
			GetComponent<SpriteRenderer>().color = new Color(0,0,0);
		}
		
	}
}
