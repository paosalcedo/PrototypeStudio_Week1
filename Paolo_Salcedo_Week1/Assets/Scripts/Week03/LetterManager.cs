using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LetterManager : MonoBehaviour {
    WordSpawner wordSpawner;
    public List<Letter> RotatedLetters = new List<Letter>();
    public List<Letter> AllLetters = new List<Letter>();
    public bool IsWordAlive = true;

    void Start() {
        wordSpawner = FindObjectOfType<WordSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.PageDown)) {
        //	letters.AddRange(wordSpawner.lettersAlive);
        //	if (CheckIfAllLettersAreUpright())
        //	{
        //		wordSpawner.lettersAlive.Clear();
        //	}
        //}
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            OutOfTimeAnimation();
        }

        if (IsWordAlive) {
            MoveLetters();
        }

        
    }

    private void MoveLetters() {
        foreach (var letter in AllLetters) {
            letter.Move();
        }
    }

    private void AddNewlySpawnedLettersToList()
    {
        RotatedLetters.AddRange(FindObjectsOfType<Letter>());
    }

    public void CheckIfAllLettersAreUpright() {
        int n = 0;
        foreach (var letter in RotatedLetters) {
            if (letter.Rotation >= 360) {
                n++;    
            }
        }
        //if all letters are upright, then AscendLetters()
        if (n == RotatedLetters.Count) { 
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
        IsWordAlive = false;
        foreach (var letter in AllLetters) {
            Destroy(letter.gameObject);
        }
        AllLetters.Clear();
    }


    public bool IsTweening;

    public void SetTweenStatus() {
        IsTweening = !IsTweening;
    }

    public void IncorrectlyTypedLetterAnimation(Letter letter) {
        if (!IsTweening) { 
            Sequence testSequence = DOTween.Sequence();
            testSequence.Append(letter.TextMesh.DOColor(Color.white, 0.25f));
            testSequence.Append(letter.TextMesh.DOColor(Color.black, 1f));
            testSequence.AppendCallback(SetTweenStatus);
        }
        //if (!incorrectSequence.IsComplete())
        //{
        //    //letter.transform.localScale = Vector3.one;
        //    //incorrectSequence.Append(letter.transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 0.75f));
        //}
        //else
        //{
        //    Debug.Log("Tween still active, can't play yet!");
        //}
    }

    private void OutOfTimeAnimation() {
        foreach (var letter in FindObjectsOfType<Letter>())
        {
            //float a = Random.Range(-2.5f, -4f);
            float rotateDuration = Random.Range(1f, 2f);
            float randomAngle = Random.Range(-180f, -90f);
            Sequence mySequence = DOTween.Sequence();
            //mySequence.Append(letter.transform.DOShakePosition(0.5f));
            mySequence.Append(letter.transform.DOMoveY(-100, 5));
            mySequence.Join(letter.transform.DORotate(new Vector3(randomAngle, letter.transform.rotation.y, letter.transform.rotation.z), rotateDuration, RotateMode.Fast).SetLoops<Tween>(5));
            mySequence.AppendInterval(5f);
            mySequence.OnComplete(DestroyExistingLetters);
        }
    }
}
