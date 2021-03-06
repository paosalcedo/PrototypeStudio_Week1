﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "Player"){
			TextManager.instance.RevealText(TextManager.instance.texts[1], 4f);
			Destroy(TextManager.instance.texts[3]);
			Vendor vendor = FindObjectOfType<Vendor>();
			Animator vendorAnim = vendor.GetComponent<Animator>();
			vendorAnim.enabled = true;
			coll.gameObject.GetComponent<MyPlayer>().foundGoal = true;
		}
	}
}
