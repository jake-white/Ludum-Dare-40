using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour {
	private bool opened = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void open() {
		opened = true;
	}

	public bool isOpened() {
		return opened;
	}
}
