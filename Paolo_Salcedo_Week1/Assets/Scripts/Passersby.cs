using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passersby : MonoBehaviour {

	float walkSpeed = 0f;
	float headRotateSpeed = 100f;
	Transform head;
	MyPlayer player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<MyPlayer>();
		head = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		// head.Rotate(transform.up * headRotateSpeed * Time.deltaTime);
		if(Vector3.Distance(player.transform.position, transform.position) <= 5f){
			head.LookAt(player.transform);
		}
		
		transform.Translate(transform.forward * walkSpeed * Time.deltaTime, Space.World);
	}
}
