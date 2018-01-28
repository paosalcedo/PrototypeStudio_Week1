using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : MonoBehaviour {
	MyPlayer player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<MyPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(player.transform.position, transform.position) <= 10f){
			transform.LookAt(player.transform);
		}
	}
}
