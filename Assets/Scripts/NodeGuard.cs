using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGuard : GuardScript {

	public GameObject[] nodes;
	private int nextNode = 0;
	private bool turning = true;

	public override void customStart() {}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform target = nodes[nextNode].transform;
		if(!turning)
		{
			float step = 1.0f * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
			if(transform.position == target.position)
			{
				nextNode++;
				turning = true;
			}
		}
		else
		{
			transform.right = target.position - transform.position;
			float angle = 10;
			Debug.Log(transform.forward);
		}

		if(nextNode > nodes.Length - 1)
		{
			nextNode = 0;
		}
	}
}
