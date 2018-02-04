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
		// rb.velocity = InputActions.moveVector * moveSpeed;
		// rb.AddForce(InputActions.moveVector * moveSpeed, ForceMode.Force);
		rb.AddRelativeTorque(new Vector3(0, 0, InputActions.moveVector.x) * 50, ForceMode.Force);
		rb.AddRelativeTorque(new Vector3(-InputActions.moveVector.z, 0, 0) * 50, ForceMode.Force);
		// rb.AddRelativeTorque(new Vector3(0, InputActions.moveVector.y, 0) * 10000, ForceMode.Force);
		float myRotation = 0;
		myRotation += InputActions.moveVector.y;
		transform.Rotate(new Vector3(0, myRotation, 0));

		// if(Input.GetKey(KeyCode.A)){            
		// 	rb.AddRelativeTorque(new Vector3(InputAction.moveVector.x, 0, 0) * 10000, ForceMode.Force);
		// }

		// if(Input.GetKey(KeyCode.D)){
		// 	rb.AddRelativeTorque(new Vector3(-1, 0, 0) * 10000, ForceMode.Force);
		// }

		// if(Input.GetKey(KeyCode.W)){
		// 	rb.AddRelativeTorque(new Vector3(0, 0, 1) * 10000, ForceMode.Force);
		// }

		// if(Input.GetKey(KeyCode.S)){
		// 	rb.AddRelativeTorque(new Vector3(0, 0, -1) * 10000, ForceMode.Force);
		// }

		// if(Input.GetKey(KeyCode.Q)){
		// 	rb.AddRelativeTorque(new Vector3(0, -1, 0) * 2500, ForceMode.Force);
		// }

		// if(Input.GetKey(KeyCode.E)){
		// 	rb.AddRelativeTorque(new Vector3(0, 1, 0) * 2500, ForceMode.Force);
		// }

		if(Input.GetKey(KeyCode.Space)){
			Time.timeScale = 1;
			Destroy(GameObject.Find("Canvas"));
		}



		//Ship Rotation
		// myRotation += InputActions.rotation;
		// transform.rotation = Quaternion.Euler(0, myRotation, 0);

		//Restart
		if(InputActions.restart_game){
			SceneManager.LoadScene("Week02");
		}
	}

}
