using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeIn : MonoBehaviour {

	Image myImage;
	float transparency = 0;
	// Use this for initialization
	void Start () {
		myImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(transparency);
		transparency += 0.2f * Time.deltaTime;
		myImage.color = new Vector4(0, 0, 0, transparency);
	}
}
