using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinJitter : MonoBehaviour {
	
	public float perlinJitter;
	public float xMultiplier;
	public float yMultiplier;
	public float zMultiplier;
	Vector3 startPos;

	float timeScale = 0.251f;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		perlinJitter = Mathf.PerlinNoise(Time.time * timeScale,0);
		if(GetComponent<Camera>() == null){
			// PositionNoise();
			RotationNoise();
		} else {
		}
	}

	public void PositionNoise(){
		transform.localPosition = new Vector3 (perlinJitter * xMultiplier, transform.localPosition.y, transform.localPosition.z);
		// transform.Translate(transform.right * perlinJitter * xMultiplier, Space.Self);
	}

	public void RotationNoise(){
 		transform.localEulerAngles = new Vector3 (perlinJitter * xMultiplier, transform.rotation.y, perlinJitter * zMultiplier);
	}

}
