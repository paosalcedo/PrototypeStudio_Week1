using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour {
	WordSpawner wordSpawner;
	private List<Letter> letters = new List<Letter>();
	
	void Start () {
		wordSpawner = FindObjectOfType<WordSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown(KeyCode.PageDown)) {
		//	letters.AddRange(wordSpawner.lettersAlive);
		//	if (CheckIfAllLettersAreUpright())
		//	{
		//		wordSpawner.lettersAlive.Clear();
		//	}
		//}
		if (Input.GetKeyDown(KeyCode.Delete)) {
			letters.AddRange(FindObjectsOfType<Letter>());
		}
		if (Input.GetKeyDown(KeyCode.PageDown)) {
			if (!CheckIfAllLettersAreUpright())
			{
				Debug.Log("Some letters are not upright!");
			}
			else {
				Debug.Log("ALL LETTERS UPRIGHT");
				WordSpawner.RemoveWord(letters);
				letters.Clear();
			}

		}
	}

	public bool CheckIfAllLettersAreUpright() {
		foreach (var letter in letters) {
			if (letter.transform.eulerAngles != Vector3.zero)
			{
				return false;
			}
        }
		return true;
	}
}
