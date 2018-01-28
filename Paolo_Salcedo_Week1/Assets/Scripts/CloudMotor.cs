using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMotor : MonoBehaviour {

	public float speed;
	public int myCloudMaker = 0;
	private float startSpeed;
	// Use this for initialization
	public virtual void Start () {
		startSpeed = speed;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		MoveCloud();
	}

	public virtual void MoveCloud(){
		transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
	}

	public virtual void CarStop(){
		speed = 0;
	}

	public void CarGo(){
		speed = startSpeed;
	}

	public virtual IEnumerator KillMe(float delay){
		yield return new WaitForSeconds(delay);
		Destroy(gameObject);	
	}

	public virtual void OnTriggerEnter(Collider hit){
		if(hit.GetComponent<Killzone>() != null){
			Destroy(gameObject, 3f);
 		}
	}

}
