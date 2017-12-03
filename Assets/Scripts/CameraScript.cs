using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public GameObject player;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = new Vector3(0, 0, -10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}
