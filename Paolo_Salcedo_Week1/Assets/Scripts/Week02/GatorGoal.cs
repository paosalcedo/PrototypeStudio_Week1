using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class GatorGoal : MonoBehaviour {
 	// Use this for initialization

	public static GatorGoal instance;
	public bool playerIsInGoal = false;
	[SerializeField]float timeInGoal = 0;

	void Start () {
		if(instance == null){
			instance = this;
		} else {
			Destroy(instance);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider hit){
		// Debug.Log("You made it!");
		if(hit.GetComponentInChildren<Player>() != null){
			// Debug.Log("You made it!");
			playerIsInGoal = true;
			timeInGoal += Time.deltaTime;
			if(timeInGoal >= 3f){
				TextManager_Week02.instance.texts[4].gameObject.SetActive(true);
				TextManager_Week02.instance.texts[2].gameObject.SetActive(false);
				TextManager_Week02.instance.texts[3].gameObject.SetActive(false);
				Time.timeScale = 0;
			}
		}
	}

	void OnTriggerExit(Collider hit){
		playerIsInGoal = false;
		timeInGoal = 0;
	}
}
