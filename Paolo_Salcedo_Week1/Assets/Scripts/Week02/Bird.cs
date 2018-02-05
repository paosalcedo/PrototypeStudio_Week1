using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bird : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Sequence mySequence = DOTween.Sequence();
		mySequence.Append(transform.DOLocalRotate(new Vector3(0, 45,0 ), 0.5f, RotateMode.Fast));
		mySequence.Append(transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast));
		mySequence.SetLoops(-1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
