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
    List<Side> _sides;
    char[] chars;
    public List<Side> Sides {
        get{ return _sides; }
    }

    public event Action<string> OnAnswerChanged;


    private void Awake()
    {
        _sides = new List<Side>(GetComponentsInChildren<Side>());
        
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
        

        // from UnfoldedDie
        this.chars = chars;
        var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
        foreach (var side in _sides)
        {
            var randomIndex = numbers[UnityEngine.Random.Range(0, numbers.Count)];
            numbers.Remove(randomIndex);
            side.Letter = chars[randomIndex-1].ToString().ToUpper();
        }

    }


    void Update()
    {

    }

    public void CheckForLetter(string letter)
    {

        foreach (var side in Sides)
        {
            if (side.Letter == letter.ToUpper() && !side.IsTyped)
            {
                _typedLetters += side.Letter;
                OnAnswerChanged?.Invoke(_typedLetters);
                side.MarkAsTyped();
                _sidesTyped.Add(side);
                return;
            }
        }

    }

    public void ClearTypedLetters()
    {
        _typedLetters = "";
        OnAnswerChanged?.Invoke(_typedLetters);

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
        OnAnswerChanged?.Invoke(_typedLetters);
        _sidesTyped[_typedLetters.Length].MarkAsUntyped();
        _sidesTyped.RemoveAt(_typedLetters.Length);
    }

    public void ActivateHint()
    {
        if (_isHintActivated) return;
        _isHintActivated = true;
        var firstLetter = _wordPossibilities[0].Substring(0, 1);
        Sides.Find(x => x.Letter.ToUpper() == firstLetter.ToUpper()).MarkAsHint();
    }

    public void Scramble()
    {
        // unfoldedDie.Scramble()
        var posList = new List<Vector3>();
        
        foreach (var side in Sides)
        {
            posList.Add(side.transform.position);
        }
        posList.Shuffle<Vector3>(new System.Random());
        for (var i = 0; i < posList.Count; i++)
        {
            Sides[i].transform.position = posList[i];
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


