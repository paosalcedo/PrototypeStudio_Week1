using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LetterManager : MonoBehaviour {
	WordSpawner wordSpawner;
	public List<Letter> Letters = new List<Letter>();

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
            AscendLetters();
        }
	}

    private void AscendLetters() {
        foreach (var letter in FindObjectsOfType<Letter>()) { 
            // Grab a free Sequence to use
            Sequence mySequence = DOTween.Sequence();
            // Add a movement tween at the beginning
            mySequence.Append(letter.transform.DOShakePosition(0.5f));
            // Add a rotation tween as soon as the previous one is finished
            mySequence.Append(letter.transform.DOMoveY(100, 5f));
            // Delay the whole Sequence by 1 second
            //mySequence.PrependInterval(1);
            // Insert a scale tween for the whole duration of the Sequence
            //mySequence.Insert(0, transform.DOScale(new Vector3(3, 3, 3), mySequence.Duration()));
            //letter.transform.DOMove
        }
    }
}
