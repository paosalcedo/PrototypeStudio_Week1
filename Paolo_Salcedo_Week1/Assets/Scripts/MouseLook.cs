using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	public float perlinJitter;
	public float xMultiplier;
	public float yMultiplier;
	public float zMultiplier;
 
	// Use this for initialization

	Vector2 mouseLook;
	Vector2 smoothV;

	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	GameObject character;
	float timeScale = 0.251f;

	void Start () {
		character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mousePos = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
		
		perlinJitter = Mathf.PerlinNoise(Time.time * timeScale,0);

		mousePos = Vector2.Scale (mousePos, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, mousePos.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, mousePos.y, 1f / smoothing);
		mouseLook += smoothV;
		mouseLook.y = Mathf.Clamp (mouseLook.y, -90f, 90f);

		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y * perlinJitter*yMultiplier, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x * perlinJitter * xMultiplier, character.transform.up);
	}
}
