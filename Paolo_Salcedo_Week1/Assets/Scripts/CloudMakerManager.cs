using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMakerManager : MonoBehaviour {

	public int myNum = 0;
	public bool timeMoves = true;
	public float multiplier = 0;
	public float timer;
	public float timerMax;
 	public float speed;
	// Use this for initialization
	public virtual void Start () {
		timer = Random.Range(0.1f, 1);
		timerMax = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if(timeMoves){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			SpawnRandom();
			timer = Random.Range(1,3);
		}
	}

	public virtual void SpawnRandom(){
		GameObject cloud = Instantiate(Resources.Load("Prefabs/Car0"+ (int)Random.Range(1,4)), transform.position, transform.rotation) as GameObject;
		// cloud.transform.localScale = new Vector3(Random.Range (3,10), Random.Range(3,10), Random.Range(3,10));
		// cloud.transform.eulerAngles = new Vector3(0, Random.Range(0,359), 0);
		cloud.GetComponent<CloudMotor>().speed = speed;
		cloud.GetComponent<CloudMotor>().myCloudMaker = myNum;
	}

	public void FreezeTime(){
		timeMoves = false;
	}

	public void UnfreezeTime(){
		timeMoves = true;
	}

}
