using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour {
	
	private Rigidbody rb;
	public float perlinJitter;
	public float xMultiplier;
	public float yMultiplier;
	public float zMultiplier;
	Vector3 startPos;

	float timeScale = 0.251f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		perlinJitter = Mathf.PerlinNoise(Time.time * timeScale,0);
		PositionNoise();
		// RotationNoise();
	}

	public void PositionNoise(){
		// transform.localPosition = new Vector3 (perlinJitter * xMultiplier, perlinJitter * yMultiplier, perlinJitter*zMultiplier);
		rb.AddForce(new Vector3 (perlinJitter * xMultiplier, 0, perlinJitter*zMultiplier), ForceMode.Force);
		// transform.Translate(transform.right * perlinJitter * xMultiplier, Space.Self);
	}

	public void RotationNoise(){
 		transform.localEulerAngles = new Vector3 (perlinJitter * xMultiplier, perlinJitter*yMultiplier, perlinJitter * zMultiplier);
	}

}
