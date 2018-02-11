using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

	[SerializeField]float rotationSpeed = 0;
	[SerializeField]int rotationDir = 0;
	// Use this for initialization
	void Start () {
		rotationDir = Random.Range (1, 3);
		// rotationSpeed = Random.Range (1, 20);
		if(rotationDir == 1){
			rotationDir = 1;
		} else if (rotationDir == 2){
			rotationDir = -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(transform.forward * rotationSpeed * rotationDir);
	}
}
