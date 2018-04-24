using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviorTree;
using NUnit.Framework;
using UnityEngine.Networking.NetworkSystem;

public class Passersby : CloudMotor {

 	float headRotateSpeed = 100f;
	Transform head;
	MyPlayer player;
	private Tree<Passersby> tree;
	private float activeRange = 3f;

	public bool iDontSeePlayer = true;
	// Use this for initialization
	public override void Start () {
		base.Start();
		tree = new Tree<Passersby>(
			new Selector<Passersby>(
				
				new Sequence<Passersby>(
					
				),
				
				new Sequence<Passersby>(
					new IsNearPlayer(),
					new StopAndStare()
				),
				
				new Move()
			)	
		);
		player = FindObjectOfType<MyPlayer>();
		head = transform.GetChild(0);
	}
	
	// Update is called once per frame
	public override void Update ()
    {
 	    tree.Update(this);
//		HeadRotate();
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
	
	/////////
	//NODES//
	/////////

	private class IsNearPlayer : Node<Passersby>
	{
		public override bool Update(Passersby context)
		{
			var playerPos = context.player.transform.position;
			var passersbyPos = context.transform.position;
			return Vector3.Distance(playerPos, passersbyPos) < context.activeRange;
		}
	}

	private class Move : Node<Passersby>
	{
		public override bool Update(Passersby context)
		{	
			context.MoveCloud();
			return true;
		}
	}

	private class StopAndStare : Node<Passersby>
	{
		public override bool Update(Passersby context)
		{
			context.transform.LookAt(context.player.transform);
			return true;
		}
	}
}
