using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyPlayer : MonoBehaviour {

	public bool foundGoal = false;

	public float endTimer = 0;
	private Camera myCam;
	// Use this for initialization
	void Start () {
		myCam = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(foundGoal){
			endTimer += Time.deltaTime;
			myCam.transform.LookAt(GameObject.Find("HalalVendorTarget").transform);
			GetComponent<FPSController>().enabled = false;
			GetComponentInChildren<MouseLook>().enabled = false;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			if(endTimer >= 5){
				TextManager.instance.texts[5].enabled = true;
				TextManager.instance.texts[6].enabled = true;
				TextManager.instance.texts[7].enabled = true;
				TextManager.instance.texts[7].text = RoundManager.instance.regretLevel.ToString("F0");
			}
		}
	}

	void OnTriggerEnter(Collider coll){	
		//stop all cars on that side of the road.
		if(coll.gameObject.tag == "Detector"){
 			RoundManager.instance.aCarSeesPlayer = true;
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
 			RoundManager.instance.aCarSeesPlayer = false;
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
