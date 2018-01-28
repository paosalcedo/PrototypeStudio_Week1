using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : CloudMakerManager {

	// Use this for initialization
	public override void Start () {
		timer = Random.Range(0.1f, 1);		
	}
	
	// Update is called once per frame
	public override void Update () {
		if(timeMoves){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			SpawnRandom();
			timer = Random.Range(5,15);
		}
	}

	public override void SpawnRandom(){
		GameObject person = Instantiate(Resources.Load("Prefabs/Person"), transform.position, transform.rotation) as GameObject;
		person.transform.localScale = new Vector3(Random.Range(0.5f,0.7f), Random.Range(0.5f,0.7f), Random.Range(0.5f,0.7f));
		// human.transform.eulerAngles = new Vector3(0, Random.Range(0,359), 0);
		person.GetComponent<CloudMotor>().speed = -speed;
		person.GetComponent<CloudMotor>().myCloudMaker = myNum;
	}
}
