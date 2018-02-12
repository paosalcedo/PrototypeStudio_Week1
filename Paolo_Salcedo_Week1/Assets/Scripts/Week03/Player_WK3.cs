using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player_WK3 : MonoBehaviour {
	Rewired.Player player;
	private int playerId = 0;
 	[SerializeField]string letterPressed;
	public TextMeshPro myTextMesh;
	public Text failTextTitle;
	public Text failTextA;
	public Text failTextB;
	public Text failTextC;
	public Text failTextD;
	float rotation = 0;
	float rotInterval = 45;
	LetterSpawner letterSpawner;	
	ScoreKeeper_WK3 scoreKeeper;

	PlayerAudioManager_WK3 audioManager_WK3;
	// Use this for initialization
	void Start () {
		player = ReInput.players.GetPlayer(playerId);
		letterSpawner = FindObjectOfType<LetterSpawner>();
		myTextMesh = GetComponent<TextMeshPro>();
		myTextMesh.text = "";
		scoreKeeper = FindObjectOfType<ScoreKeeper_WK3>();
		audioManager_WK3 = GetComponent<PlayerAudioManager_WK3>();
	}
	
	// Update is called once per frame
	void Update () {
		// if()
		GetInput();
		ProcessInput();
		transform.eulerAngles = new Vector3(0, 0, rotation);
 	}

	void GetInput(){
		WK3_Inputs.i_pressA = player.GetButtonDown("Press A");
		WK3_Inputs.i_pressB = player.GetButtonDown("Press B");
		WK3_Inputs.i_pressC = player.GetButtonDown("Press C");
		WK3_Inputs.i_pressD = player.GetButtonDown("Press D");
		WK3_Inputs.i_pressE = player.GetButtonDown("Press E");
		WK3_Inputs.i_pressF = player.GetButtonDown("Press F");
		WK3_Inputs.i_pressG = player.GetButtonDown("Press G");
		WK3_Inputs.i_pressH = player.GetButtonDown("Press H");
		WK3_Inputs.i_pressI = player.GetButtonDown("Press I");
		WK3_Inputs.i_pressJ = player.GetButtonDown("Press J");
		WK3_Inputs.i_pressK = player.GetButtonDown("Press K");
		WK3_Inputs.i_pressL = player.GetButtonDown("Press L");
		WK3_Inputs.i_pressM = player.GetButtonDown("Press M");
		WK3_Inputs.i_pressN = player.GetButtonDown("Press N");
		WK3_Inputs.i_pressO = player.GetButtonDown("Press O");
		WK3_Inputs.i_pressP = player.GetButtonDown("Press P");
		WK3_Inputs.i_pressQ = player.GetButtonDown("Press Q");
		WK3_Inputs.i_pressR = player.GetButtonDown("Press R");
		WK3_Inputs.i_pressS = player.GetButtonDown("Press S");
		WK3_Inputs.i_pressT = player.GetButtonDown("Press T");
		WK3_Inputs.i_pressU = player.GetButtonDown("Press U");
		WK3_Inputs.i_pressV = player.GetButtonDown("Press V");
		WK3_Inputs.i_pressW = player.GetButtonDown("Press W");
		WK3_Inputs.i_pressX = player.GetButtonDown("Press X");
		WK3_Inputs.i_pressY = player.GetButtonDown("Press Y");
		WK3_Inputs.i_pressZ = player.GetButtonDown("Press Z");
	}

	void ProcessInput(){
		if(WK3_Inputs.i_pressA){
			letterPressed = "a";
 			RotateLetter();
 		}

		if(WK3_Inputs.i_pressB){
			letterPressed = "b";
 			RotateLetter();
		} 

		if(WK3_Inputs.i_pressC){
			letterPressed = "c";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressD){
			letterPressed = "d";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressE){
			letterPressed = "e";
 			RotateLetter();
 		}

		if(WK3_Inputs.i_pressF){
			letterPressed = "f";
 			RotateLetter();
		} 

		if(WK3_Inputs.i_pressG){
			letterPressed = "g";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressH){
			letterPressed = "h";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressI){
			letterPressed = "i";
 			RotateLetter();
 		}

		if(WK3_Inputs.i_pressJ){
			letterPressed = "j";
 			RotateLetter();
		} 

		if(WK3_Inputs.i_pressK){
			letterPressed = "k";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressL){
			letterPressed = "l";
			RotateLetter();
		}
			if(WK3_Inputs.i_pressM){
			letterPressed = "m";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressN){
			letterPressed = "n";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressO){
			letterPressed = "o";
 			RotateLetter();
 		}

		if(WK3_Inputs.i_pressP){
			letterPressed = "p";
 			RotateLetter();
		} 

		if(WK3_Inputs.i_pressQ){
			letterPressed = "q";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressR){
			letterPressed = "r";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressS){
			letterPressed = "s";
 			RotateLetter();
 		}

		if(WK3_Inputs.i_pressT){
			letterPressed = "t";
 			RotateLetter();
		} 

		if(WK3_Inputs.i_pressU){
			letterPressed = "u";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressV){
			letterPressed = "v";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressW){
			letterPressed = "w";
 			RotateLetter();
 		}

		if(WK3_Inputs.i_pressX){
			letterPressed = "x";
 			RotateLetter();
		} 

		if(WK3_Inputs.i_pressY){
			letterPressed = "y";
			RotateLetter();
		}
		if(WK3_Inputs.i_pressZ){
			letterPressed = "z";
			RotateLetter();
		}
		else {
			letterPressed = "";
		}
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.GetComponent<Letter>() != null){
			
			Letter letterHit = coll.gameObject.GetComponent<Letter>();
  			if(letterHit.myString == "o" /* || letterHit.myString == "i" || letterHit.myString == "h" || letterHit.myString == "x" || letterHit.myString == "y" || letterHit.myString == "z" || letterHit.myString == "s" */){
				DestroyIncomingLetter(letterHit);
				scoreKeeper.score += 1;
				StartCoroutine(CameraShake.Shake(this.transform, 0.05f));
				audioManager_WK3.PlaySuccess();
			} 
			else if(Mathf.Round(letterHit.gameObject.transform.eulerAngles.z) == Mathf.Round(transform.eulerAngles.z)){
				DestroyIncomingLetter(letterHit);
 				scoreKeeper.score += 1;
				StartCoroutine(CameraShake.Shake(this.transform, 0.05f));
				audioManager_WK3.PlaySuccess();
			} else if (Mathf.Round(letterHit.gameObject.transform.eulerAngles.z) != Mathf.Round(transform.eulerAngles.z)){
				ShowFailureMessage(letterHit.myString);
				Time.timeScale = 0;								
				//  SceneManager.LoadScene("Week03_v3");
				// Debug.LogError("Enemy was at " + Mathf.Round(letterHit.gameObject.transform.eulerAngles.z) + " Player was at " + Mathf.Round(transform.eulerAngles.z));
 			}
		}
	}

	void RotateLetter(){
		if (letterPressed == myTextMesh.text){
			rotation += rotInterval;
			audioManager_WK3.PlayRotate();
		}
	}

	void DestroyIncomingLetter(Letter _letter){
		Destroy (_letter.gameObject);
		letterSpawner.lettersAlive.Clear();
	}

	void ShowFailureMessage(string _letter){
		failTextA.gameObject.SetActive(true);
		failTextA.text = _letter;
		failTextB.gameObject.SetActive(true);
		failTextB.text = _letter;
		failTextTitle.gameObject.SetActive(true);
		failTextC.gameObject.SetActive(true);
		failTextD.gameObject.SetActive(true);
		GameObject.Find("Game").SetActive(false);
		GameObject letterAlive = FindObjectOfType<Letter>().gameObject;
		letterAlive.SetActive(false);
	}

}
