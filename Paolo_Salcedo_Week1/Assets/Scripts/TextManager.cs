using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour {

	public Text[] texts;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(FadeText(3f, texts[0]));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FadeText(float delay, Text _text){
		yield return new WaitForSeconds(delay);
		_text.CrossFadeAlpha(0, 5f, true);
	}
}
