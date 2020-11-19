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
        //if all letters are upright, then AscendLetters()
        if (n == Letters.Count) { 
            CorrectAnimation();
        }
	}

    private void CorrectAnimation() {
        foreach (var letter in FindObjectsOfType<Letter>()) { 
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(letter.transform.DOShakePosition(0.5f));
            mySequence.Append(letter.transform.DOMoveY(100, 5f));
            mySequence.OnComplete(DestroyExistingLetters);
        }
    }

    private void DestroyExistingLetters() {
        foreach (var letter in FindObjectsOfType<Letter>()) {
            letter.gameObject.SetActive(false);
        }
    }

    private void OutOfTimeAnimation() {
        foreach (var letter in FindObjectsOfType<Letter>())
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(letter.transform.DOShakePosition(0.5f));
            mySequence.Append(letter.transform.DOMoveY(100, 5f));
            mySequence.OnComplete(DestroyExistingLetters);
        }
    }
}
