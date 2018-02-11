using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Letter : MonoBehaviour {

	TextMeshPro textMesh;
	public string myString;
	public float speed;

	int angleInterval;
	// Use this for initialization
	void Start () {
		angleInterval = Random.Range(1, 9);
		textMesh = GetComponent<TextMeshPro>();
		transform.eulerAngles = new Vector3(0, 0, angleInterval * 45);
 	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.back * speed * Time.deltaTime);
		textMesh.text = myString;
		Debug.Log("Enemy " + myString + " is "  + angleInterval * 45);
	}
}
