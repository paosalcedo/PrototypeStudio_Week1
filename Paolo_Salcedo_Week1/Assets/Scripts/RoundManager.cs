using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

	public static RoundManager instance; 
	public float regretLevel;
	public float multiplier = 1;
	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
		} else {
			Destroy(instance);
		}
	}
	
	// Update is called once per frame
	void Update () {
		regretLevel += Time.deltaTime * multiplier;
		// if()
	}
}
