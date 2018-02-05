using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager_Week02 : MonoBehaviour {

	public enum GameState{
		Paused,
		GameOn
	}

	public GameState myGameState; 
	public Gator gator;
	public Bird bird;
	public GameObject sceneRoot;
  	void Awake()
	{
		InitializeServices();
	}

	// Use this for initialization
	void Start()
	{
		myGameState = GameState.Paused;
		Time.timeScale = 0;
 		 		// Services.EventManager.Register<Reset>(Reset);
		// Services.SceneStackManager.PushScene<TitleScreen>();
	}

	// Update is called once per frame
	void Update()
	{
		Services_Week02.RoundManager_Week02.FindGator(gator, bird);
		Services_Week02.RoundManager_Week02.Update();

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

		if(myGameState == GameState.Paused){
			if(Input.GetKeyDown(KeyCode.Space)){
				Time.timeScale = 1;
				myGameState = GameState.GameOn;
				TextManager_Week02.instance.texts[0].enabled = false;
				TextManager_Week02.instance.texts[1].enabled = false;
				TextManager_Week02.instance.texts[13].enabled = false;
				TextManager_Week02.instance.texts[2].enabled = true;
				TextManager_Week02.instance.texts[3].enabled = true;
			}

			if(Input.GetKeyDown(KeyCode.N)){
				GameObject.Find("Obstacles").SetActive(false);
				myGameState = GameState.GameOn;
				TextManager_Week02.instance.texts[0].enabled = false;
				TextManager_Week02.instance.texts[1].enabled = false;
				TextManager_Week02.instance.texts[13].enabled = false;
				TextManager_Week02.instance.texts[2].enabled = true;
				TextManager_Week02.instance.texts[3].enabled = true;
				Time.timeScale = 1;
			}
		}
	}

	void InitializeServices()
	{
		Debug.Log("Services initialized!");
		Services_Week02.GameManager_Week02 = this;
		Services_Week02.RoundManager_Week02 = new RoundManager_Week02();
		// Services_Week02.RoundManager_Week02.FindGator() 
	}

	// void Reset(Reset e)
	// {
	// 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	// }

	//UI buttons
}

public class RoundManager_Week02 {
	float distance;

	public void Update(){
		TextManager_Week02.instance.texts[3].text = distance.ToString("F0");

		if(distance <= 0.5f){
			if(!GatorGoal.instance.playerIsInGoal){
				TextManager_Week02.instance.texts[12].gameObject.SetActive(true);
				Debug.Log("hey");
				Time.timeScale = 0;
  			}
		}
	}
	public void FindGator(Gator _gator, Bird _bird){
		distance = Vector3.Distance(_gator.transform.position, _bird.transform.position) - 30;
	}
}
