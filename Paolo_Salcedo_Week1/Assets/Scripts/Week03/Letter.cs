using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Rewired;
using DG.Tweening;

public class Letter : MonoBehaviour {

    public TextMeshPro TextMesh
    {
        get
        {
            return textMesh;
        }
    }
    private TextMeshPro textMesh;
	public string MyString; //public string--probably set from somewhere
	public float Speed;
	Rewired.Player player;
	private int playerId = 0;
	[SerializeField] string letterPressed;
	PlayerAudioManager_WK3 audioManager_WK3;
	LetterManager letterManager;

	public float Rotation { get; private set; }
	

	float rotInterval = 45;
	public bool IsControllable = false;



	int angleInterval; //there are 9 intervals of 45 degrees in 360
	// Use this for initialization
	void Start () {
		player = ReInput.players.GetPlayer(playerId);
		letterManager = FindObjectOfType<LetterManager>();
		Debug.Assert(letterManager != null, "Letter.cs : Can't find LetterManager!");
		angleInterval = Random.Range(1, 9); //we randomize the angle of the Letter transform by randomizing angleInterval.
		textMesh = GetComponent<TextMeshPro>();
		Rotation = transform.eulerAngles.z;
		//Debug.Log("Hello world! " + "I am " + MyString + ". My rotation is " + Rotation);
        //transform.eulerAngles = new Vector3(0, 0, angleInterval * 45); //we then apply it to the transform here.
    }

	// Update is called once per frame
	void Update () {
		//if (IsControllable) { 
		//	GetInput();
		//	ProcessInput();
		//}
		GetInput();
		ProcessInput();
		textMesh.text = MyString; //always setting the text property of the mesh to the assigned letter.
		//transform.eulerAngles = new Vector3(0, 0, rotation);
		//Debug.Log("Enemy " + myString + " is "  + angleInterval * 45);
	}

	public void Move() {
		transform.Translate(Vector3.back * Speed * Time.deltaTime); //movement
	}

	private void ProcessInput()
    {
		if (WK3_Inputs.i_pressA)
		{
			letterPressed = "a";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressB)
		{
			letterPressed = "b";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressC)
		{
			letterPressed = "c";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressD)
		{
			letterPressed = "d";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressE)
		{
			letterPressed = "e";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressF)
		{
			letterPressed = "f";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressG)
		{
			letterPressed = "g";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressH)
		{
			letterPressed = "h";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressI)
		{
			letterPressed = "i";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressJ)
		{
			letterPressed = "j";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressK)
		{
			letterPressed = "k";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressL)
		{
			letterPressed = "l";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressM)
		{
			letterPressed = "m";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressN)
		{
			letterPressed = "n";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressO)
		{
			letterPressed = "o";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressP)
		{
			letterPressed = "p";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressQ)
		{
			letterPressed = "q";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressR)
		{
			letterPressed = "r";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressS)
		{
			letterPressed = "s";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressT)
		{
			letterPressed = "t";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressU)
		{
			letterPressed = "u";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressV)
		{
			letterPressed = "v";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressW)
		{
			letterPressed = "w";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressX)
		{
			letterPressed = "x";
			RotateLetter();
		}

		if (WK3_Inputs.i_pressY)
		{
			letterPressed = "y";
			RotateLetter();
		}
		if (WK3_Inputs.i_pressZ)
		{
			letterPressed = "z";
			RotateLetter();
		}
		else
		{
			letterPressed = "";
		}
	}


    private void GetInput()
    {
		WK3_Inputs.i_pressA = player.GetButtonDown("Press A");
		WK3_Inputs.i_pressB = player.GetButtonDown("Press B");
		WK3_Inputs.i_pressC = player.GetButtonDown("Press C");
		WK3_Inputs.i_pressD = player.GetButtonDown("Press D");
		WK3_Inputs.i_pressE = player.GetButtonDown("Press E");
		WK3_Inputs.i_pressF = player.GetButtonDown("Press F");
		WK3_Inputs.i_pressG = player.GetButtonDown("Press G");
		WK3_Inputs.i_pressH = player.GetButtonDown("Press H");
		WK3_Inputs.i_pressI = player.GetButtonDown("Press I");
		WK3_Inputs.i_pressJ = player.GetButtonDown("Press J");
		WK3_Inputs.i_pressK = player.GetButtonDown("Press K");
		WK3_Inputs.i_pressL = player.GetButtonDown("Press L");
		WK3_Inputs.i_pressM = player.GetButtonDown("Press M");
		WK3_Inputs.i_pressN = player.GetButtonDown("Press N");
		WK3_Inputs.i_pressO = player.GetButtonDown("Press O");
		WK3_Inputs.i_pressP = player.GetButtonDown("Press P");
		WK3_Inputs.i_pressQ = player.GetButtonDown("Press Q");
		WK3_Inputs.i_pressR = player.GetButtonDown("Press R");
		WK3_Inputs.i_pressS = player.GetButtonDown("Press S");
		WK3_Inputs.i_pressT = player.GetButtonDown("Press T");
		WK3_Inputs.i_pressU = player.GetButtonDown("Press U");
		WK3_Inputs.i_pressV = player.GetButtonDown("Press V");
		WK3_Inputs.i_pressW = player.GetButtonDown("Press W");
		WK3_Inputs.i_pressX = player.GetButtonDown("Press X");
		WK3_Inputs.i_pressY = player.GetButtonDown("Press Y");
		WK3_Inputs.i_pressZ = player.GetButtonDown("Press Z");
	}

	private void RotateLetter()
	{
		if (letterPressed == textMesh.text)
		{
			if (IsControllable) { 
				Rotation = transform.eulerAngles.z;
				Rotation += rotInterval;
				transform.eulerAngles = new Vector3(0, 0, Rotation);
				letterManager.CheckIfAllLettersAreUpright();
			}
            else
            {
				IncorrectlyTypedLetterAnimation(this);
            }
		}

		//if (letterPressed == textMesh.text)
		//{
		//	rotation += rotInterval;
		//	//audioManager_WK3.PlayRotate();
		//}
	}

	public bool IsIncorrectlyTypedLetterAnimationTweening;

	public void SetIncorrectlyTypedLetterAnimationTweenStatus()
	{
		IsIncorrectlyTypedLetterAnimationTweening = !IsIncorrectlyTypedLetterAnimationTweening;
	}

	public void IncorrectlyTypedLetterAnimation(Letter letter)
	{
		if (!IsIncorrectlyTypedLetterAnimationTweening)
		{
			Sequence testSequence = DOTween.Sequence();
			testSequence.PrependCallback(SetIncorrectlyTypedLetterAnimationTweenStatus);
			testSequence.Append(letter.transform.DOPunchScale(new Vector3(1.05f, 1.05f, 1.05f), 0.3f));
			testSequence.Join(letter.TextMesh.DOColor(Color.white, 0.25f));
			testSequence.Append(letter.TextMesh.DOColor(Color.black, 0.15f));
			testSequence.AppendCallback(SetIncorrectlyTypedLetterAnimationTweenStatus);
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

}
