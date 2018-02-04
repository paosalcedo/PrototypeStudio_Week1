using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Passersby : CloudMotor {

 	float headRotateSpeed = 100f;
	Transform head;
	MyPlayer player;

	public bool iDontSeePlayer = true;
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

	public override void MoveCloud(){
		transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
	}

    private void HeadRotate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 3f)
        {
            head.LookAt(player.transform);
			iDontSeePlayer = false;
 			if(!RoundManager.instance.npcsWhoSeePlayer.Contains(this)){
				RoundManager.instance.npcsWhoSeePlayer.Add(this);
			}
 			// Text judgmentText = Instantiate(Resources.Load("Prefabs/JudgmentText"), )			
			// TextManager.instance.texts[3].enabled = true;
			// Time.timeScale = 0;
        } else {
			head.localEulerAngles = Vector3.zero;
			iDontSeePlayer = true;
			if(RoundManager.instance.npcsWhoSeePlayer.Contains(this)){
				RoundManager.instance.npcsWhoSeePlayer.Remove(this);
			}
		}
    }
}
