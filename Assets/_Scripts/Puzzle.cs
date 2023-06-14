using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using TMPro;
using DG.Tweening;
using static ExtensionMethods.ListExtensions;


public class Puzzle : MonoBehaviour
{
    Canvas _canvas;
    UnfoldedDie unfoldedDie;


    string[] _wordPossibilities;
    public string[] WordPossibilities
    {
        get { return _wordPossibilities; }
    }
    string _typedLetters;
    public string TypedLetters
    {
        get { return _typedLetters; }
    }

    bool hintActivated;
    public bool HintActivated
    {
        get { return hintActivated; }

    }



    int _letterCount;
    public int LetterCount
    {
        get { return _letterCount; }
    }
    List<Side> _sidesTyped;

    public static event Action<string, bool> OnSuccess;
    public static event Action<string, bool> OnSkip;



    private void Awake()
    {

        unfoldedDie = GetComponentInChildren<UnfoldedDie>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hintActivated = false;
        //Time.timeScale = 1f;
        _typedLetters = "";
        _letterCount = 0;
        _wordPossibilities = GameManager.Instance.GetWordArray();

        var chars = _wordPossibilities[0].ToCharArray();
        _sidesTyped = new List<Side>();
        unfoldedDie.Init(chars);



        // skip, submit

    }



    // Update is called once per frame
    void Update()
    {

    }

    public void NextPuzzle()
    {

        GameManager.Instance.NextPuzzle();
    }



    public void CheckForLetter(string letter)
    {

        foreach (var side in unfoldedDie.Sides)
        {
            if (side.Letter == letter.ToUpper() && !side.IsTyped)
            {
                _typedLetters += side.Letter;
                _letterCount++;
                UIManager.Instance.SetTypedLettersText(_typedLetters);
                side.MarkAsTyped();
                _sidesTyped.Add(side);
                return;
            }
        }
        unfoldedDie.GetComponent<UnfoldedDieAnimation>().Shake();
    }

    public void ClearTypedLetters()
    {
        _typedLetters = "";
        _letterCount = 0;
        UIManager.Instance.SetTypedLettersText(_typedLetters);

        foreach (var side in _sidesTyped)
        {
            side.MarkAsUntyped();
        }
        _sidesTyped.Clear();
    }

    public void ClearLastTypedLetter()
    {
        if (_letterCount == 0) return;
        _letterCount--;
        _typedLetters = _typedLetters.Substring(0, _letterCount);
        UIManager.Instance.SetTypedLettersText(_typedLetters);
        // _typedLettersText.text = _typedLettersText.text.Substring(0, _letterCount);
        _sidesTyped[_letterCount].MarkAsUntyped();
        _sidesTyped.RemoveAt(_letterCount);
    }


    // TODO: rename this and the animator trigger to Success
    public void Pass()
    {
        GameManager.Instance.PuzzleTransitionStart();
        UIManager.Instance.RevealAnswer(_typedLetters, true);
        ScoreManager.Instance.PlayerPasses();
        AudioSystem.Instance.PlayBellSound();
        GetComponent<Animator>().SetBool("Pass", true);
        Timer.Instance.PlayerPasses();
    }

    public void Skip()
    {
        GameManager.Instance.PuzzleTransitionStart();
        UIManager.Instance.RevealAnswer(_typedLetters, false);
        ScoreManager.Instance.PlayerSkips();
        AudioSystem.Instance.PlayBuzzerSound();
        GetComponent<Animator>().SetTrigger("Skip");
        Timer.Instance.PlayerSkips();
    }

    public bool ActivateHint()
    {
        if (hintActivated) return false;
        hintActivated = true;
        var firstLetter = _wordPossibilities[0].Substring(0, 1);
        Debug.Log("First Letter: " + firstLetter);
        unfoldedDie.ActivateHint(firstLetter);
        return true;
    }

    public void Scramble()
    {
        // unfoldedDie.Scramble()
        var posList = new List<Vector3>();
        var sides = unfoldedDie.Sides;
        foreach (var side in sides)
        {
            posList.Add(side.transform.position);
        }
        posList.Shuffle<Vector3>(new System.Random());
        for (var i = 0; i < posList.Count; i++)
        {
            sides[i].transform.position = posList[i];
        }
    }

    public void Submit()
    {
        if (_letterCount != 6) return;
        if (this.IsWordValid(_typedLetters, _wordPossibilities))
        {
            this.Pass();

        }

    }

    public void OnTextInput(char ch)
    {
        this.CheckForLetter(ch.ToString());
    }
    
    // TODO: rename to IsSubmissionValid
    public bool IsWordValid(string wordEntered, string[] wordPossibilities)
    {
        foreach (var word in wordPossibilities)
        {
            if (word.ToUpper() == wordEntered.ToUpper())
            {
                return true;
            }
        }
        return false;
    }


}


