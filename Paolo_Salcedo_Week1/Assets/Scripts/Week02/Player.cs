using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {
	Rewired.Player player;
	private int playerId = 0;

	private Vector3 moveVector;
	private float myRotation = 0;
	Rigidbody rb;
	private Vector3 startPos;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.Locked;
		// Cursor.visible = false;
		player = ReInput.players.GetPlayer(playerId);
		rb = GetComponent<Rigidbody>();
		startPos = transform.position;
	}

	void Update(){
		GetInput();
		ProcessInput();

		if(transform.position.y <= -20f){
			if(transform.position != startPos){
				TextManager_Week02.instance.texts[Random.Range(5, 11)].gameObject.SetActive(true);
				// if(TextManager_Week02.instance.texts[5].ena)
				for (int i = 5; i<12; ++i){
					if(TextManager_Week02.instance.texts[i].gameObject.activeInHierarchy){
						StartCoroutine(TextManager_Week02.instance.DisableText(3f, i));
					}
				}

				// StartCoroutine(TextManager_Week02.instance.DisableText(3f, 6));
				// StartCoroutine(TextManager_Week02.instance.DisableText(3f, 7));
				// StartCoroutine(TextManager_Week02.instance.DisableText(3f, 8));
				// StartCoroutine(TextManager_Week02.instance.DisableText(3f, 9));
				// StartCoroutine(TextManager_Week02.instance.DisableText(3f, 10));
				// StartCoroutine(TextManager_Week02.instance.DisableText(3f, 11));
				// StartCoroutine(TextManager_Week02.instance.DisableText(3f, 5));
			}
 			transform.position = startPos;
			rb.angularVelocity = Vector3.zero;
			transform.rotation = Quaternion.Euler(0,0,0);
		}
 	}

	void FixedUpdate(){
		// ProcessInput();
	}
	
	void GetInput(){
 		InputActions.moveVector.x = player.GetAxis("Rotate Y");
		InputActions.moveVector.z = player.GetAxis("Rotate X");
		InputActions.moveVector.y = player.GetAxis("Rotate Z");
 		InputActions.restart_game = player.GetButtonDown("Restart");
 	}

	void ProcessInput(){
		//Movement
		if(!GatorGoal.instance.playerIsInGoal){
			rb.AddRelativeTorque(new Vector3(0, 0, InputActions.moveVector.x) * 50, ForceMode.Force);
			rb.AddRelativeTorque(new Vector3(-InputActions.moveVector.z, 0, 0) * 50, ForceMode.Force);
			float myRotation = 0;
			myRotation += InputActions.moveVector.y;
			transform.Rotate(new Vector3(0, myRotation, 0));
		}


		//Restart
		if(InputActions.restart_game){
			SceneManager.LoadScene("Week02");
		}

	}

	public void StopMovement(){
		Debug.Log("Stopping movement!");
		// rb.angularVelocity = Vector3.zero;
		// transform.rotation = Quaternion.Euler(0,0,0);
	}

}
