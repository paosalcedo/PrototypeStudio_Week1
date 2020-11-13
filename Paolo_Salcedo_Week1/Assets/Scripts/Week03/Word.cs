using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Word : MonoBehaviour {

	private List<Player_WK3> playerLetters = new List<Player_WK3>();
	[SerializeField]private List<string> word = new List<string>(); //made of a list of single letters
	// Use this for initialization
	void Start () {
		//GameObject letter = (GameObject)Instantiate(Resources.Load("Prefabs/Week03/Letter"), Vector3.forward * 20, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
	}


	//the WordSpawner spawns the letters that form the word, passes it to this class
	public void SetWord(string s) { 
		char[] charArr = s.ToCharArray();
		foreach (char ch in charArr)
		{
			word.Add(ch.ToString());
		}
	}

	public void SpawnPlayableLetters(string a, Vector3 pos, Quaternion rotation) {
		GameObject g = Instantiate(Resources.Load("Prefabs/Week03/Letter"), pos, Quaternion.identity) as GameObject;
		g.transform.position = new Vector3(pos.x, pos.y, -16.5f);
		Letter l = g.GetComponent<Letter>();
		l.MyString = a;
		l.Speed = 0;
		l.GetComponent<TextMeshPro>().color = Color.white;
    }


}
