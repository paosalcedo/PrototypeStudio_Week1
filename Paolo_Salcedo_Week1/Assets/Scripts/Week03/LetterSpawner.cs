﻿using System.Collections;
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
	[SerializeField]private int numActiveLetters = 3;
	public List<string> words = new List<string>() {
		"Awesome","Formidable","Exalted","Colorful","Frantic","Majestic"
	};

	public List<GameObject> lettersAlive = new List<GameObject>(); 
	void Start () {
		player = FindObjectOfType<Player_WK3>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //ramps up the move speed of each spawned letter over time.
        IncreaseLetterMoveSpeed();
        SpawnWord();
    }

    private void SpawnWord()
    {
        if (lettersAlive.Count <= 0)
        {       //needs to only spawn when there are no other letters in the Scene.

            //NEW WORD SYSTEM

            wordIndex = Random.Range(0, TextData.Words.Count);
            List<string> spawnedWord = new List<string>();
            //pass the selected word to "Word" class
            //this is a terrible way but let's get it working first
            GameObject.Find("Word").GetComponent<Word>().SetWord(TextData.Words[wordIndex]);
            //use foreach to go through each letter in the selected word and convert to charArr.
            char[] charArr = TextData.Words[wordIndex].ToCharArray();
            foreach (char ch in charArr)
            {
                spawnedWord.Add(ch.ToString());
            }
            float x = -10; //starting position of the first letter
            float kerning = 2.75f; //spacing between each letter
            for (int i = 0; i < spawnedWord.Count; i++)
            {
                //first letter should spawn at x = -10
                // Vector3.forward * 20
                GameObject letter = (GameObject)Instantiate(Resources.Load("Prefabs/Week03/Letter"), Vector3.forward * 20, Quaternion.identity);
                letter.GetComponent<Letter>().MyString = spawnedWord[i]; //take a specific letter at index i from the spawnedWord list of words
                x += kerning;
                letter.transform.position = new Vector3(x, letter.transform.position.y, letter.transform.position.z);

                //only add active letters until there's a max of 3
                if (lettersAlive.Count <= 3)
                {
                    //add some randomization so it's not every letter?
                    int r = Random.Range(0, 100);
                    int angle = Random.Range(0, 359);
                    if (r >= 66)
                    {
                        letter.transform.Rotate(Vector3.forward * angle, Space.Self);
                        lettersAlive.Add(letter);
                    }
                }

                //player.myTextMesh.text = letter.GetComponent<Letter>().myString;
                //letter.GetComponent<Letter>().Speed = letterMoveSpeed;
            }
        }
    }

    private void IncreaseLetterMoveSpeed()
    {
		letterMoveSpeed += 0.1f * Time.deltaTime;
    }
}
