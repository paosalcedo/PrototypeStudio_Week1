using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {

	float t;
	GameObject gator;
	// Use this for initialization
	void Start () {
		gator = FindObjectOfType<Gator>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		LerpToPosition();
	}

	void LerpToPosition(){
		t += 0.00002f * Time.deltaTime;
		transform.position = Vector3.Lerp(transform.position, gator.transform.position + gator.transform.forward * 20, t);
	}
}
