using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPatrol : GuardScript {
	private Vector2 moveDirection;
	private Vector3 turnAmount;
	private Vector3 targetTurn;
	private float speed = 0;
	private bool turning = false;
	private float movementSpeed = 4.0f;

	public override void customStart() {
		moveDirection = Vector2.up;
		turnAmount = new Vector3(0,0,180);
		
		speed = movementSpeed;
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if(collision.collider != player.GetComponent<Collider2D>() && !turning) {
			turning = true;
			speed = 0;
			if(targetTurn ==  new Vector3(0,0,180)) {
				targetTurn = new Vector3(0,0,360);
			}
			else {
				targetTurn = new Vector3(0,0,180);
			}
			
		}

	}

	void Update () {
		if(!state.isCaught()) {
		base.sight();
			if(!turning)
			{
				transform.Translate(moveDirection * speed * Time.deltaTime);
			}
			else {
				Vector3 moreOrLess = turnAmount * Time.deltaTime;
				transform.Rotate(moreOrLess);
				if(transform.eulerAngles.z - targetTurn.z <= moreOrLess.z && transform.eulerAngles.z - targetTurn.z >= -moreOrLess.z) {
					transform.Rotate(targetTurn - transform.eulerAngles);
					speed = movementSpeed;
					transform.Translate(moveDirection * speed * Time.deltaTime);
					turning = false;
				}
			}
		}
		
	}
}
