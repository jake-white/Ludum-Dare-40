using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D coll) {
			if(coll.GetComponent<GuardScript>() !=null)
			{
				coll.GetComponent<GuardScript>().setSoundTarget();
			}
    }

	void OnTriggerExit2D(Collider2D coll) {
			if(coll.GetComponent<GuardScript>() !=null)
			{
				coll.GetComponent<GuardScript>().loseSoundTarget();
			}
    }
}
