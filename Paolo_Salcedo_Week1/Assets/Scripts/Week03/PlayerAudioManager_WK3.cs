using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager_WK3 : MonoBehaviour {

	public AudioSource aSource;
	// Use this for initialization
	public AudioClip[] clips;
	void Start () {
		aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySuccess(){
		aSource.pitch = Random.Range(1f, 1.5f);
		aSource.clip = clips[0];
		aSource.PlayScheduled(AudioSettings.dspTime + 0.0000001f);
	}

	public void PlayRotate(){
		aSource.pitch = Random.Range(1f, 1.1f);
		aSource.clip = clips[1];
		aSource.PlayScheduled(AudioSettings.dspTime + 0.0000001f);
	}
}
