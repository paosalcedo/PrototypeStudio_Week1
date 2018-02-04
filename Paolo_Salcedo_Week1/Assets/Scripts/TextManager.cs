using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour {

	public static TextManager instance;
	public Text[] texts;

	public Image[] images;
	
	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
		} else {
			Destroy(this);
		}
		StartCoroutine(FadeTextDelayed(3f, texts[0]));
 	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FadeTextDelayed(float delay, Text _text){
		yield return new WaitForSeconds(delay);
		_text.CrossFadeAlpha(0, 3f, false);
 	}

	public void FadeText(Text _text, float _fadeTime){
 		_text.CrossFadeAlpha(0, _fadeTime, false);
 	}
	public void RevealText(Text _text, float _fadeDelay){
		_text.enabled = true;
		StartCoroutine(FadeTextDelayed(_fadeDelay, _text));
		StartCoroutine(RevealImage(_fadeDelay, images[0].gameObject));
	}

	IEnumerator RevealImage(float delay, GameObject _image){
		// _image.CrossFadeAlpha(1, 5f, false);
		yield return new WaitForSeconds(delay);
		_image.SetActive(true);
	}
}
