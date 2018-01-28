using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passersby : CloudMotor {

 	float headRotateSpeed = 100f;
	Transform head;
	MyPlayer player;
	// Use this for initialization
	public override void Start () {
		base.Start();
		player = FindObjectOfType<MyPlayer>();
		head = transform.GetChild(0);
	}
	
	// Update is called once per frame
	public override void Update ()
    {
		base.Update();
		HeadRotate();
     }

    private void HeadRotate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 5f)
        {
            head.LookAt(player.transform);
        }
    }
}
