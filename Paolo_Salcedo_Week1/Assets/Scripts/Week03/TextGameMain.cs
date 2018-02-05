using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGameMain : MonoBehaviour {

	private float timePressed = 0;
	public KeyCode wKey;
	public KeyCode sKey;

	void Awake(){

	}

	void InitializeTextData(){
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// TextData.textData.Update()
		CycleText(wKey);
		CycleText(sKey);
	}

	public void CycleText(KeyCode key){
		if(Input.GetKey(key)){
			switch(key){
				case KeyCode.W:
				timePressed += Time.deltaTime;
				if(timePressed >= 5f && timePressed < 10f){
					Debug.Log("Hey"); 
				} else if (timePressed >= 10f){
					Debug.Log("What's up");
				}
				break;
				case KeyCode.S:
				break; 
				default:
				timePressed = 0;
				break;
			}
		}
	}
}
