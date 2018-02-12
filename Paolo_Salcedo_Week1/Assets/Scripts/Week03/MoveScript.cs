using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {
	[SerializeField]float speed;
	[SerializeField]Vector3 direction;
	Vector3 pos;
	Vector3 startPos;

	public bool isMovingHorizontally = false;
	public bool isMovingVertically = false;
	public bool canMove = true;
	// [SerializeField]
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		if(direction.x != 0){
			isMovingHorizontally = true;
		} else {
			isMovingHorizontally = false;
		}
 	}
	
	// Update is called once per frame
	void Update () {
		if(canMove){
			transform.Translate(direction * speed * Time.deltaTime);
		} 
		// pos = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
		pos = Camera.main.WorldToViewportPoint(transform.position);
		// Debug.Log("y " + pos.y);
		// Debug.Log("x " + pos.x);
		if(isMovingHorizontally){
			ResetHorizontalPosition();
		} else {
			ResetVerticalPosition();			
		}

 		
 	}

	void ResetVerticalPosition(){
		if(pos.y >= 1 || pos.y <= -1){
			transform.position = startPos;		
		}
	}
	
	void ResetHorizontalPosition(){
		if(pos.x >= 1 || pos.x <= -1){
			transform.position = startPos;		
		}
	}
}
