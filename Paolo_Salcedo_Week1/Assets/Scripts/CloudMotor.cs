using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMotor : MonoBehaviour {

	public float speed;
	public int myCloudMaker = 0;
	private float startSpeed;
	// Use this for initialization
	void Start () {
		startSpeed = speed;
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

	public void CarStop(){
		speed = 0;
	}

	public void CarGo(){
		speed = startSpeed;
	}


}
