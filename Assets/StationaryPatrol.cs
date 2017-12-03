using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryPatrol : GuardScript {

	public override void customStart() {
	}

	void Update () {
		if(!state.isCaught()) {
			base.sight();
		}
		
	}
}
