using System.Collections;
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
			Debug.Log("Hello sir what is your order");
		}
	}
}
