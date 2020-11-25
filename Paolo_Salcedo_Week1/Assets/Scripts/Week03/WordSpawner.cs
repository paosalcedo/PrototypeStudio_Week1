using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

	// Use this for initialization	
	[SerializeField]float timer;
	[SerializeField]float spawnTime;
	[SerializeField]float letterMoveSpeed = 10;
    [SerializeField]private int lettersAliveCount;
    [SerializeField]private int maxRotatedLetters = 3;

    Word currentWord;
    LetterManager letterManager;
	public string[] Letters = {"a", "b", "c", "d", "e", "f", "g", "h", "i",
	"j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
	private int letterIndex = 0;
	private int wordIndex = 0; //out of whatever number of elements there are in the "words" list
	[SerializeField]private int numActiveLetters = 3;
	public List<string> words = new List<string>() {
		"Awesome","Formidable","Exalted","Colorful","Frantic","Majestic"
	};

    private int spawned = 0;

	public List<Letter> RotatedLetters = new List<Letter>(); 
	void Start () {
        letterManager = FindObjectOfType<LetterManager>();
        Debug.Assert(letterManager != null, "Can't find LetterManager class");
        currentWord = FindObjectOfType<Word>();
        Debug.Assert(currentWord != null, "Can't find Word class");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //ramps up the move speed of each spawned letter over time.
        //IncreaseLetterMoveSpeed();

        if (Input.GetKeyDown(KeyCode.PageUp)) {
            SpawnWord();
        }
    }

    public static void RemoveWord(List<Letter> spawnedLetters)
    {

        foreach (var letter in spawnedLetters)
        {
            letter.gameObject.SetActive(false);
            Destroy(letter.gameObject);
        }
    }

    public void SpawnWord()
    {
        if (FindObjectsOfType<Letter>().Length >= 0)
        { //if there are letters in the game
            RotatedLetters.Clear();
            List<Letter> spawnedLetters = new List<Letter>();
            spawnedLetters.AddRange(FindObjectsOfType<Letter>()); //then spawn letters and add them to the spawnedLetters list SO WE CAN DESTROY THEM
            RemoveWord(spawnedLetters);
        }
        //needs to only spawn when there are no other letters in the Scene.

        //NEW WORD SYSTEM
        letterManager.IsWordAlive = true; // tell LetterManager that a word is alive, to allow for Move() function in Letter.cs
        wordIndex = Random.Range(0, TextData.Words.Count);
        List<string> spawnedWord = new List<string>();

        //pass the selected word to "Word" class
        //this is a terrible way but let's get it working first

        //GameObject.Find("WordPlayer").GetComponent<Word>().SetWord(TextData.Words[wordIndex]);
        //Debug.Log(TextData.Words[wordIndex]);

        //use foreach to go through each letter in the selected word and convert to charArr.


        char[] charArr = TextData.Words[wordIndex].ToCharArray();

        foreach (char ch in charArr)
        {
            spawnedWord.Add(ch.ToString());
        }
        float x = -10; //starting position of the first letter
        float kerning = 2.75f; //spacing between each letter
        for (int i = 0; i < TextData.Words[wordIndex].Length; ++i)
        {
            //first letter should spawn at x = -10
            // Vector3.forward * 20
            float spawnDistance = 100;

            GameObject g = Instantiate(Resources.Load("Prefabs/Week03/Letter"), Vector3.forward * spawnDistance, Quaternion.identity) as GameObject;
            Letter letter = g.GetComponent<Letter>();
            letter.GetComponent<Letter>().MyString = spawnedWord[i]; //take a specific letter at index i from the spawnedWord list of words
            x += kerning;
            letter.transform.position = new Vector3(x, letter.transform.position.y, letter.transform.position.z);

            //only add active letters until there's a max of 3
            letterManager.AllLetters.Add(letter);
            if (RotatedLetters.Count <= maxRotatedLetters)
            {
                //int r = Random.Range(0, 100);   //add some randomization so it's not every letter?
                int angle = Random.Range(1, 8);
                int angleInterval = 45;

                if (

                    //r >= 67 && 

                    !RotatedLetters.Contains(letter))
                {
                    letter.transform.Rotate(Vector3.forward * (angle * angleInterval), Space.Self); //we rotate the letter to a random rotation
                    RotatedLetters.Add(letter);
                    letterManager.RotatedLetters.Add(letter);
                    letter.IsControllable = true; //we only want to control/rotate the letters that are not upright
                    //currentWord.SpawnPlayableLetters(letter.MyString, letter.transform.position, letter.transform.rotation);
                }
            }

            //player.myTextMesh.text = letter.GetComponent<Letter>().myString;
            letter.GetComponent<Letter>().Speed = letterMoveSpeed;
        }
  
        spawned++;
    }
    private void IncreaseLetterMoveSpeed()
    {
		letterMoveSpeed += 0.1f * Time.deltaTime;
    }
}
