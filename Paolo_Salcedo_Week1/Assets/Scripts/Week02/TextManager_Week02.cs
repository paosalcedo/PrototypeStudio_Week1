using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager_Week02 : MonoBehaviour {

	public static TextManager_Week02 instance;
	public Text[] texts;

	public Image[] images;
	
	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
		} else {
			Destroy(this);
		}
 	}

	public IEnumerator DisableText(float delay, int _textNum){
		yield return new WaitForSeconds(delay);
		texts[_textNum].gameObject.SetActive(false);
	}

	
}
