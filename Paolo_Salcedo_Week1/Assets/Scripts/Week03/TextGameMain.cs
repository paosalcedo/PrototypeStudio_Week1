using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextGameMain : MonoBehaviour {

	#region wStrings
	private List<string> wStrings = new List<string>(){
		"run",
		"away",
		"distance",
		"escape",
		"flight",
		"depart",
		"regret",
		"else",
		"consequence",
		"left",
		"leave",
		"mistake",
		"drunk",
		"irreparable",
		"no",
		"getaway",
		"drive",
		"trip",
		"lost",
		"broken",
		"dark",
		"rain",
		"clogged",
		"worst",
		"potholes",
		"traffic",
		"magnolia",
		"tonkatsu",
		"insecurity",
		"settled",
		"second",
		"inferior",
		"bored",

	};
	#endregion

	#region sStrings
	private List<string> sStrings = new List<string>(){
		"brandy",
		"cigarettes",
		"eyeliner",
		"breath",
		"dancing",
		"whispers",
		"mixtapes",
		"Holland",
		"1945",
		"Awake",
		"flailing",
		"never",
		"again",
		"burger",
		"drunk",
		"beer",
		"endless",
		"pints",
		"dream",
		"smoke",
		"kebab",
		"hiding",
		"storm",
		"warm",
		"impulse",
		"kiss",
		"balcony",
		"tongue",
		"view",
		"backalley",
		"sidestreet",
		"intoxication",
		"inebriation",
		"dance",
		"text",
		"underground",
		"rain",
		"puddles",
		"cockblocks",
		"muscle",
		"cars",
		"rice",
		"rocket",
		"pimped",
		"cackle"
	};
	#endregion

	#region dStrings
	private List<string> dStrings = new List<string>(){
		"out-of-town",
		"elsewhere",
		"different",
		"tiny",
		"piercing",
		"sharp",
		"quiet",
		"knowing",
		"hidden",
		"truth",
		"waiting",
		"origami",
		"flock",
		"paper",
		"hair",
		"Jack",
		"whiskey",
		"corner",
		"inside",
		"wishes",
		"black",
		"hairspray",
		"accent",
		"soft",
		"imagination",
		"flights",
		"meetings"
	};
	#endregion

	#region aStrings
	private List<string> aStrings = new List<string>() {
		"omakase",
		"missed",
		"discarded",
		"<i>tapas</i>",
		"nothing",
		"chance",
		"waiting",
		"ignored",		
		"<i>futbol</i>",
		"rampaging",
		"fullback",
		"wine",
		"silent",
		"fiery",
		"Amarone",
		"Madrid",
		"never",
		"<i>left-foot</i>",
		"friends"	
	};
	#endregion
	public TextMeshPro text;
	public float timePressed = 3;
	public KeyCode wKey;
	public KeyCode sKey;
	public KeyCode dKey;
	public KeyCode aKey;

	[SerializeField]int wIndex = 0;
	[SerializeField]int sIndex = 0;
	[SerializeField]int aIndex = 0;
	[SerializeField]int dIndex = 0;

	void Awake(){
 	}

	 

	// Use this for initialization
	void Start () {
		aKey = KeyCode.A;
		dKey = KeyCode.D;
		text.text = wStrings[0]; 
		text.enableWordWrapping = true;
	}
	
	// Update is called once per frame
	void Update () {
		// text.text = wStrings[wIndex];
 
		// TextData.textData.Update()
		CycleText(wKey);
		CycleText(sKey);
		CycleText(aKey);
		CycleText(dKey);
	}

	private bool isFontReset = false;
	public void CycleText(KeyCode key){
		if(Input.GetKey(key)){
			switch(key){
				case KeyCode.W:
					VaryTextSize(wIndex, 10);
					text.text = wStrings[wIndex];
					text.transform.position = Vector3.zero;
					if (wIndex == wStrings.Count-1){
						wIndex = 0;
					} else if(wIndex <= wStrings.Count-1){
						wIndex++;
					}
				break;
				case KeyCode.S:
					VaryTextSize(sIndex, 3);
					text.text = sStrings[sIndex];
					text.transform.position = Vector3.zero;
					if (sIndex == sStrings.Count-1) {
						sIndex = 0;
					} else if(sIndex <= sStrings.Count-1){
						sIndex++;
					} 
				break;
				case KeyCode.D:
					text.text = dStrings[dIndex];
					text.transform.position = transform.right * 5;
 					if (dIndex == dStrings.Count-1) {
						dIndex = 0;
					} else if(dIndex <= dStrings.Count-1){
						dIndex++;
					} 
				break;  
				case KeyCode.A:
					text.text = aStrings[aIndex];
					text.rectTransform.position = -transform.right * 5f;
 					if (aIndex == aStrings.Count-1) {
						aIndex = 0;
					} else if(aIndex <= aStrings.Count-1){
						aIndex++;
					} 
				break;  
				default:

				break;
			} 
		}
	}

	void VaryTextSize(int _textIndex, int modulo){
	
		if(_textIndex % modulo == 0){
			text.fontSize = 64;
		} else {
			text.fontSize = 16;
		}
	}

}
