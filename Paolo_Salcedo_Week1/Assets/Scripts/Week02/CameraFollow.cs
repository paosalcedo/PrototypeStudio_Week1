using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	float t;
 	Camera myCam;
 	// Use this for initialization
	void Start () {
		myCam = FindObjectOfType<Camera>();
 	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // LerpToObjectPositionForTopDownView();
		LerpToObjectThirdPerson();
    }

	void Update(){
		// LerpToObjectThirdPerson();

 	}

    private void LerpToObjectPositionForTopDownView()
    {
        if (myCam.WorldToScreenPoint(transform.position).x < Screen.width * 0.49f
                || myCam.WorldToScreenPoint(transform.position).x > Screen.width * 0.51f
                || myCam.WorldToScreenPoint(transform.position).y < Screen.height * 0.49f
                || myCam.WorldToScreenPoint(transform.position).y > Screen.height * 0.51f
                )
        {
            t += 0.02f * Time.deltaTime;
            myCam.transform.position = new Vector3(Mathf.Lerp(myCam.transform.position.x, transform.position.x, t), myCam.transform.position.y, Mathf.Lerp(myCam.transform.position.z, transform.position.z, t));
        }
    }

	private void LerpToObjectThirdPerson(){
 		if (myCam.WorldToScreenPoint(transform.position).x < Screen.width * 0.45f
                || myCam.WorldToScreenPoint(transform.position).x > Screen.width * 0.55f
                || myCam.WorldToScreenPoint(transform.position).y < Screen.height * 0.45f
                || myCam.WorldToScreenPoint(transform.position).y > Screen.height * 0.55f
                )
		{
			t += 0.02f * Time.deltaTime;
			myCam.transform.position = new Vector3(Mathf.Lerp(myCam.transform.position.x, transform.position.x + 8, t), myCam.transform.position.y, Mathf.Lerp(myCam.transform.position.z, transform.position.z + 2, t));
		}
	}
}
