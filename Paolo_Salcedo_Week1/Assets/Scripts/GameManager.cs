using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public GameObject sceneRoot;
	public Camera currentCamera;
	void Awake()
	{
		InitializeServices();
	}

	// Use this for initialization
	void Start()
	{
		 		// Services.EventManager.Register<Reset>(Reset);
		// Services.SceneStackManager.PushScene<TitleScreen>();
	}

	// Update is called once per frame
	void Update()
	{
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("main");
        }
	}

	void InitializeServices()
	{
		Debug.Log("Services initialized!");
		Services.GameManager = this;
	}

	// void Reset(Reset e)
	// {
	// 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	// }

	//UI buttons

}
