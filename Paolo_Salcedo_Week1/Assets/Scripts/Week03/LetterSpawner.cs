using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour {

	// Use this for initialization	
	[SerializeField]float timer;
	[SerializeField]float spawnTime;
	[SerializeField]float letterMoveSpeed;

	Player_WK3 player;
	public string[] letters = {"a", "b", "c", "d", "e", "f", "g", "h", "i",
	"j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
	public int myStringIndex = 0;

	public List<GameObject> lettersAlive = new List<GameObject>(); 
	void Start () {
		player = FindObjectOfType<Player_WK3>();
	}
	
	// Update is called once per frame
	void Update () {
		letterMoveSpeed += 0.1f * Time.deltaTime;
		// timer += Time.deltaTime;
		//needs to only spawn when there are no other letters in the Scene.
		if(lettersAlive.Count <= 0){
			GameObject letter = (GameObject)Instantiate(Resources.Load("Prefabs/Week03/Letter"), Vector3.forward * 20, Quaternion.identity);
			// letter.GetComponent<Letter>().myString = 
			myStringIndex = Random.Range(0, 26);
 			letter.GetComponent<Letter>().myString = letters[myStringIndex];
			lettersAlive.Add(letter);
			letter.GetComponent<Letter>().speed = letterMoveSpeed;
			player.myTextMesh.text = letter.GetComponent<Letter>().myString;
		}
	}
}
