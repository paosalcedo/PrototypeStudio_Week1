using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public GameObject sceneRoot;
	public Camera currentCamera;
	private MouseLook mouseLook;
	void Awake()
	{
		InitializeServices();
	}

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 0;
		mouseLook = FindObjectOfType<MouseLook>();
		mouseLook.enabled = false;
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

		if(Input.GetKeyDown(KeyCode.Space)){
			Time.timeScale = 1;
			mouseLook.enabled = true;
			TextManager.instance.texts[0].enabled = false;
			TextManager.instance.texts[2].enabled = false;
			TextManager.instance.texts[8].enabled = false;
	}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
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
