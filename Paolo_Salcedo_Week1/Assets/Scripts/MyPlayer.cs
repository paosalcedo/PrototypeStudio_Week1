using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "Detector"){
			//stop all cars on that side of the road.
			Debug.Log("Entered detector!");
			CloudMotor[] allCars = FindObjectsOfType<CloudMotor>();
			foreach (CloudMotor car in allCars){
				// if(car.myCloudMaker == )
				car.CarStop();
			}
		}
	}

	void OnTriggerExit(Collider coll){
		if(coll.gameObject.tag == "Detector"){
			//stop all cars on that side of the road.
			Debug.Log("Exited detector!");
			CloudMotor[] allCars = FindObjectsOfType<CloudMotor>();
			foreach (CloudMotor car in allCars){
				car.CarGo();
			}
		}
	}
}
