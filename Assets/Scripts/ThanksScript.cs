using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ThanksScript : MonoBehaviour {
	public GameState state;
	public Button title;
	public Text coinText;

	// Use this for initialization
	void Start () {
		GameObject toDestroy = GameObject.Find("DontDestroyBoi");
		coinText.text = "Score: " + toDestroy.GetComponent<SaveData>().getSavedCoins() + " Coins";
		Destroy(toDestroy);
        title.onClick.AddListener(TitleScreen);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TitleScreen() {
		SceneManager.LoadScene("Menu");
	}
}
