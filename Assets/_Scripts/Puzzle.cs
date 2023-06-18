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

    [SerializeField] WordList _wordList;


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

    bool _isHintActivated;
    List<Side> _sidesTyped;




    private void Awake()
    {

        unfoldedDie = GetComponentInChildren<UnfoldedDie>();
    }

    private void OnEnable()
    {
        HintTracker.OnUsedHint += ActivateHint;
    }

    private void OnDisable()
    {
        HintTracker.OnUsedHint -= ActivateHint;
    }

    // Start is called before the first frame update
    void Start()
    {
        _isHintActivated = false;
        _typedLetters = "";
        _wordPossibilities = _wordList.GetWordPossibilities();

        var chars = _wordPossibilities[0].ToCharArray();
        _sidesTyped = new List<Side>();
        unfoldedDie.Init(chars);

    }


    void Update()
    {

    }

    public void CheckForLetter(string letter)
    {

        foreach (var side in unfoldedDie.Sides)
        {
            if (side.Letter == letter.ToUpper() && !side.IsTyped)
            {
                _typedLetters += side.Letter;
                UIManager.Instance.SetTypedLettersText(_typedLetters);
                side.MarkAsTyped();
                _sidesTyped.Add(side);
                return;
            }
        }

    }

    public void ClearTypedLetters()
    {
        _typedLetters = "";
        UIManager.Instance.SetTypedLettersText(_typedLetters);

        foreach (var side in _sidesTyped)
        {
            side.MarkAsUntyped();
        }
        _sidesTyped.Clear();
    }

    public void ClearLastTypedLetter()
    {
        if (_typedLetters.Length == 0) return;
        _typedLetters = _typedLetters.Substring(0, _typedLetters.Length - 1);
        UIManager.Instance.SetTypedLettersText(_typedLetters);
        _sidesTyped[_typedLetters.Length].MarkAsUntyped();
        _sidesTyped.RemoveAt(_typedLetters.Length);
    }

    public void ActivateHint()
    {
        if (_isHintActivated) return;
        _isHintActivated = true;
        var firstLetter = _wordPossibilities[0].Substring(0, 1);
        unfoldedDie.ActivateHint(firstLetter);
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

    public bool IsSubmissionValid()
    {
        if (_typedLetters.Length != 6) return false;
        foreach (var word in _wordPossibilities)
        {
            if (word.ToUpper() == _typedLetters.ToUpper())
            {
                return true;
            }
        }
        return false;
    }
}


