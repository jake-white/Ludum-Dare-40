using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPatrol : GuardScript {
	private Vector2 moveDirection;
	private Vector3 turnAmount;
	private Vector3 targetTurn;
	private float speed = 0;
	private bool turning = false;

	public override void customStart() {
		moveDirection = Vector2.up;
		turnAmount = new Vector3(0,0,180);
		
		speed = 1;
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if(collision.collider != player.GetComponent<Collider2D>() && !turning) {
			turning = true;
			speed = 0;

			Debug.Log("Hit something not player");
			if(targetTurn ==  new Vector3(0,0,180)) {
				targetTurn = new Vector3(0,0,-90);
			}
			else {
				targetTurn = new Vector3(0,0,270);
			}
			
		}

	}

	void Update () {
		base.sight();
		if(!turning)
		{
			transform.Translate(moveDirection * speed * Time.deltaTime);
		}
		else {
			Vector3 moreOrLess = turnAmount * Time.deltaTime;
			transform.Rotate(moreOrLess);
			if(transform.eulerAngles.z + moreOrLess.z >= targetTurn.z) {
				Debug.Log(transform.eulerAngles.z + " " + moreOrLess.z + " " + targetTurn.z);
				transform.Rotate(targetTurn - transform.eulerAngles);
				speed = 1.0f;
				Debug.Log("done turning.");
				transform.Translate(moveDirection * speed * Time.deltaTime);
				turning = false;
			}
		}
		
	}
}
