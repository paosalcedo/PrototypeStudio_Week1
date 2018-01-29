using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class FPSController : MonoBehaviour {

	private PerlinJitter myPJ;
	public float speed = 10.0f;
	public float airControl = 0.1f;
	public float gravity = 10.0f;
	public float maxFallVelocity = 20f;
	public float maxVelocityChange = 10.0f;
	public float fallDeathHeight = 20f;
//	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;

//	float initHeight;


	Rigidbody rb;
	//
//	public float sideSpeed;
//	public float forwardSpeed;
//	public static float movementSpeed;
//	public float mouseSensitivity;
//
//	float verticalLook = 0; //why declare it here?
//	float verticalLookMax = 90.0f;
//	float horizontalLook;
//
//	public float verticalVelocity;
//
	void Start () {
//		soundPlayed = false;
		myPJ = GetComponent<PerlinJitter>();
		Cursor.lockState = CursorLockMode.Locked;
		rb = GetComponent<Rigidbody> ();

// 		ORIGINAL SETTINGS
		rb.freezeRotation = true;
		rb.useGravity = false;

//		MINE
//		rb.freezeRotation = true;
//		rb.useGravity = true;
	}

	
	// Update is called once per frame
	void Update(){
 	}
	void FixedUpdate()
	{
		MovePlayer ();
 //		CheckIfGrounded();
	}	

	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}

	void MovePlayer(){
		
		Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		// if(targetVelocity.x == 0 && targetVelocity.y == 0){
		Vector3 jitterVec3 = new Vector3 (myPJ.perlinJitter * myPJ.xMultiplier, 0, myPJ.perlinJitter * myPJ.zMultiplier);
	
		targetVelocity = transform.TransformDirection(targetVelocity + jitterVec3);
		targetVelocity *= speed;
		// }

		// Apply a force that attempts to reach our target velocity
		Vector3 velocity = rb.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;

		if (grounded == true) {
			rb.AddForce (velocityChange, ForceMode.VelocityChange);
		}

		//jump
		if (grounded == true && Input.GetButtonDown("Jump")) {
			rb.velocity = new Vector3 (velocity.x, CalculateJumpVerticalSpeed (), velocity.z);
			// play the jump sound.
			AudioSource jump;
			jump = GetComponent<AudioSource>();
			jump.Play();
		}

		//tweaking air control when jumping.
		if (grounded == false) {
			rb.AddForce (velocityChange * airControl, ForceMode.VelocityChange);
		}

		// We apply gravity manually for more tuning control
		rb.AddForce(new Vector3 (0, -gravity * rb.mass, 0));

		//		grounded = false;

	}

	void OnCollisionStay (Collision coll) {
		if (coll.collider.tag == "Ground") {
			grounded = true;
		}
	}

	void OnCollisionExit(Collision coll){
		grounded = false;
		if (coll.gameObject.tag == "ground") {
 		}
	}
		
}
