using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPolygon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2[] points = transform.parent.GetComponent<MeshView>().getPolygon();
		GetComponent<PolygonCollider2D>().points = points;
	}
}
