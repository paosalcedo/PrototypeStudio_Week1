using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LetterSpawner : MonoBehaviour {

	// Use this for initialization	
	[SerializeField]float timer;
	[SerializeField]float spawnTime;
	[SerializeField]float letterMoveSpeed;

	Player_WK3 player;
	public string[] Letters = {"a", "b", "c", "d", "e", "f", "g", "h", "i",
	"j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
	private int letterIndex = 0;
	private int wordIndex = 0; //out of whatever number of elements there are in the "words" list
	public List<string> words = new List<string>() {
		"Awesome","Formidable","Exalted","Colorful","Frantic","Majestic"
	};

	public List<GameObject> lettersAlive = new List<GameObject>(); 
	void Start () {
		player = FindObjectOfType<Player_WK3>();
	}
	
	// Update is called once per frame
	void Update () {
		//ramps up the move speed of each spawned letter over time.
		letterMoveSpeed += 0.1f * Time.deltaTime; 
		// timer += Time.deltaTime;

		if(lettersAlive.Count <= 0){		//needs to only spawn when there are no other letters in the Scene.
	
			//Spawn the letter
			//Debug.Log("letterMoveSpeed = " + letterMoveSpeed);
			// letter.GetComponent<Letter>().myString = 

			/*
			 OLD LETTER SYSTEM
			myStringIndex = Random.Range(0, 26);
			letter.GetComponent<Letter>().myString = letters[myStringIndex];
			 */
			
			//NEW WORD SYSTEM
			
			wordIndex = Random.Range(0, 6);
			List<string> spawnedWord = new List<string>();
			char[] charArr = words[wordIndex].ToCharArray();
			foreach (char ch in charArr) {
				spawnedWord.Add(ch.ToString());
			}
			float x = 0;
			float kerning = 2.75f;
			for (int i = 0; i < spawnedWord.Count; i++) {
				GameObject letter = (GameObject)Instantiate(Resources.Load("Prefabs/Week03/Letter"), Vector3.forward * 20, Quaternion.identity);
				letter.GetComponent<Letter>().MyString = spawnedWord[i];
				x += kerning;
                letter.transform.position = new Vector3(x, letter.transform.position.y, letter.transform.position.z);
                lettersAlive.Add(letter);
                //player.myTextMesh.text = letter.GetComponent<Letter>().myString;
                letter.GetComponent<Letter>().Speed = letterMoveSpeed;
            }
        }
	}
}
