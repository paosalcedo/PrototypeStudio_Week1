using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour {

	private List<Player_WK3> playerLetters = new List<Player_WK3>();
	[SerializeField]private List<string> word = new List<string>(); //made of a list of single letters
	// Use this for initialization
	void Start () {
		GameObject letter = (GameObject)Instantiate(Resources.Load("Prefabs/Week03/Letter"), Vector3.forward * 20, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
	}

	public void SetWord(string s) {
		char[] charArr = s.ToCharArray();
		foreach (char ch in charArr)
		{
			word.Add(ch.ToString());
		}
	}
}
