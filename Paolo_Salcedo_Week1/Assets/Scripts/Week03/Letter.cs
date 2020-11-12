using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Letter : MonoBehaviour {

	TextMeshPro textMesh;
	public string MyString; //public string--probably set from somewhere
	public float Speed;

	int angleInterval; //there are 9 intervals of 45 degrees in 360
	// Use this for initialization
	void Start () {
		angleInterval = Random.Range(1, 9); //we randomize the angle of the Letter transform by randomizing angleInterval.
		textMesh = GetComponent<TextMeshPro>();
		transform.eulerAngles = new Vector3(0, 0, angleInterval * 45); //we then apply it to the transform here.
 	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.back * Speed * Time.deltaTime); //movement
		textMesh.text = MyString; 
		//Debug.Log("Enemy " + myString + " is "  + angleInterval * 45);
	}
}
