using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMakerManager : MonoBehaviour {

	public int myNum = 0;
	float multiplier = 0;
	float timer;
	float timerMax;
	public float cloudSpeed;
	// Use this for initialization
	void Start () {
		timer = Random.Range(0.1f, 1);
		timerMax = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0){
			SpawnRandom();
			timer = Random.Range(1,3);
		}
	}

	public void SpawnRandom(){
		GameObject cloud = Instantiate(Resources.Load("Prefabs/Car0"+ (int)Random.Range(1,4)), transform.position, transform.rotation) as GameObject;
		// cloud.transform.localScale = new Vector3(Random.Range (3,10), Random.Range(3,10), Random.Range(3,10));
		// cloud.transform.eulerAngles = new Vector3(0, Random.Range(0,359), 0);
		cloud.GetComponent<CloudMotor>().speed = -cloudSpeed;
		cloud.GetComponent<CloudMotor>().myCloudMaker = myNum;
	}

}
