using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager_WK3 : MonoBehaviour {

	public static GameManager_WK3 instance;

	// Use this for initialization
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
		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene("Week03_v3");
			Time.timeScale = 1;
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene("Week03_Intro");
		} 
	}
}
