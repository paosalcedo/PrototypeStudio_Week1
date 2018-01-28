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
		//stop all cars on that side of the road.
		if(coll.gameObject.tag == "Detector"){
			CloudMotor hitCar = coll.gameObject.GetComponentInParent<CloudMotor>();
			if(hitCar.myCloudMaker == 0){
				CloudMotor[] allCars = FindObjectsOfType<CloudMotor>();
				foreach (CloudMotor car in allCars){
					if(car.myCloudMaker == 0){
						car.CarStop();
						CloudMakerManager[] allCarMakers = FindObjectsOfType<CloudMakerManager>();
						foreach (CloudMakerManager carMaker in allCarMakers){
							if(carMaker.myNum == 0){
								carMaker.FreezeTime();
							}
						}
					} 
				}
			} else {
				CloudMotor[] allCars = FindObjectsOfType<CloudMotor>();
				foreach (CloudMotor car in allCars){
					if(car.myCloudMaker == 1){
						car.CarStop();
						CloudMakerManager[] allCarMakers = FindObjectsOfType<CloudMakerManager>();
						foreach (CloudMakerManager carMaker in allCarMakers){
							if(carMaker.myNum == 1){
								carMaker.FreezeTime();
							}
						}
					} 
				}
			}
		}
	}

	void OnTriggerExit(Collider coll){
		if(coll.gameObject.tag == "Detector"){
			RoundManager.instance.multiplier = 1;
			//stop all cars on that side of the road.
 			CloudMotor[] allCars = FindObjectsOfType<CloudMotor>();
			foreach (CloudMotor car in allCars){
				car.CarGo();
				CloudMakerManager[] allCarMakers = FindObjectsOfType<CloudMakerManager>();
				foreach (CloudMakerManager carMaker in allCarMakers){
					if(carMaker.myNum == 1 || carMaker.myNum == 0){
						carMaker.UnfreezeTime();
					}
				}
			}
			
		}
	}

	void OnTriggerStay(Collider coll){
		if(coll.gameObject.tag == "Detector"){
			RoundManager.instance.multiplier = 3;
		}
	}

}
