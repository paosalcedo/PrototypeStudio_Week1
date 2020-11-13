using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager_WK3 : MonoBehaviour {

	public static GameManager_WK3 instance;

	// Use this for initialization

	//used the Singleton pattern
	void Start () {
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(this);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){ //Restarts current game, but if in intro, starts the game.
			SceneManager.LoadScene("Week03_v3");
			Time.timeScale = 1;
		}

		if(Input.GetKeyDown(KeyCode.Escape)){ // Exits to main menu
			SceneManager.LoadScene("Week03_Intro");
		} 
	}
}
