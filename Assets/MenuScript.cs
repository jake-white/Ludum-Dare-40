using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour {
	public GameState state;
	public Button play, credits;
	public Animator creditAnimator;
	private bool creditsUp = false;

	// Use this for initialization
	void Start () {
        play.onClick.AddListener(PlayLevel);
		credits.onClick.AddListener(CreditsAnimate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayLevel() {
		SceneManager.LoadScene("Floor 1");
	}

	void CreditsAnimate() {
		if(creditsUp) {
			creditAnimator.Play("CreditDown");
			creditsUp = false;
		}
		else {
			creditAnimator.Play("CreditUp");
			creditsUp = true;
		}
	}
}
