using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTurnPatrol: GuardScript {

	private Random rnd;
	private float rotateStart = 0, rotateFor = 0;
	private float speed = 10;
	private int turnDir = 1;
	public override void customStart() {
	}

	void Update () {
		if(!state.isCaught()) {
			if(Time.time * 1000 > rotateStart + rotateFor) {
				rotateFor = Random.value * 5000 + 1000;
				rotateStart = Time.time * 1000;
				speed = Random.value * 10 + 10;
				if(Random.value > 0.5f) {
					turnDir = 1;
				}
				else {
					turnDir = -1;
				}
			}
			else {
				transform.Rotate(0, 0, Time.deltaTime * speed * turnDir);
			}
			base.sight();
		}
		
	}
}
