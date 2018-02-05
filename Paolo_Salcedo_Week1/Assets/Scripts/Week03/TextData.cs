using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextData {
	public static TextData instance;

	void Start(){
		if(instance == null){
			instance = this;
		} 
	}
	public List<string> wStrings = new List<string>(){
		"taking a few steps away",
		"gaining some distance",
		"walking away.",
		"running away."
	};

	public List<string> sStrings = new List<string>(){
		"returned home",
		"it's like you never left.",
		"glad you're back.",
		"never leave again"
	};
	
}
