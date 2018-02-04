using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

	private MyPlayer player;
	public bool someoneSeesPlayer;
	public bool aCarSeesPlayer;
	public static RoundManager instance; 
	public float regretLevel;
	public float multiplier = 1;

	public List<Passersby> npcsWhoSeePlayer = new List<Passersby>();
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<MyPlayer>();
		if(instance == null){
			instance = this;
		} else {
			Destroy(instance);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!player.foundGoal){
			regretLevel += Time.deltaTime * multiplier;
		}
		// if()
		// CheckIfSomeoneSeesPlayer();
		if(TextManager.instance.texts[3] != null){
			if(npcsWhoSeePlayer.Count != 0){
				multiplier = 3;
				TextManager.instance.texts[3].enabled = true;
			} else {
				TextManager.instance.texts[3].enabled = false;
			}
		}

		if(aCarSeesPlayer){
			multiplier = 5;
			TextManager.instance.texts[4].enabled = true;
		} else {
			multiplier = 1;
			TextManager.instance.texts[4].enabled = false;
		}
	}
	void CheckIfSomeoneSeesPlayer(){
		Passersby[] everyNPC = FindObjectsOfType<Passersby>();
		// foreach (Passersby npc in everyNPC){
		// 	if(!npc.iDontSeePlayer && !npcsWhoSeePlayer.Contains(npc)){ //if passersby sees player
		// 		npcsWhoSeePlayer.Add(npc); //add to list
		// 		Debug.Log("Someone added to list!"); 
		// 	} else if (npcsWhoSeePlayer.Contains(npc) && npc.iDontSeePlayer) {
		// 		npcsWhoSeePlayer.Remove(npc);
 		// 	}
			// if(!npc.iDontSeePlayer){//someone sees player
			// 	someoneSeesPlayer = true;
			// } 
		// }
	}
}
