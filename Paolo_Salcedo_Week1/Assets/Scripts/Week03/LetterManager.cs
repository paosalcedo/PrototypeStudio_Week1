using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour {
	WordSpawner wordSpawner;
	public List<Letter> Letters = new List<Letter>();
    private bool playerAnsweredCorrectly = false;
	
	void Start () {
		wordSpawner = FindObjectOfType<WordSpawner>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.PageDown)) {
        //	letters.AddRange(wordSpawner.lettersAlive);
        //	if (CheckIfAllLettersAreUpright())
        //	{
        //		wordSpawner.lettersAlive.Clear();
        //	}
        //}
        if (playerAnsweredCorrectly) {
            AscendLetters();
        }
    }

    private void AddNewlySpawnedLettersToList()
    {
        Letters.AddRange(FindObjectsOfType<Letter>());
    }

    public void CheckIfAllLettersAreUpright() {
        int n = 0;
        foreach (var letter in Letters) {
            if (letter.Rotation >= 360) {
                n++;    
            }
        }
        if (n == Letters.Count) {
            playerAnsweredCorrectly = true;
        }
	}

    float ascendSpeed = 100f;
    private void AscendLetters() {
        foreach (var letter in FindObjectsOfType<Letter>()) {
            letter.transform.Translate(Vector3.up * ascendSpeed * Time.deltaTime);
        }
    }
}
