using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMotor : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		MoveCloud();

		//kill cloud here
		if(transform.position.x <= -300f)
			Destroy(gameObject);
	}

	public void MoveCloud(){
		transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
	}
}
