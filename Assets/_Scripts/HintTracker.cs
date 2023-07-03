using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HintTracker : MonoBehaviour
{
    [SerializeField] Button _hintButton;
    [SerializeField] TMP_Text _hintButtonText;
    public static event Action OnUsedHint;
    int _numHintsLeft;
    [SerializeField] int _startingNumHints = 5;
    public int NumHintsLeft
    {
        get { return _numHintsLeft; }
        set
        {
            if (value < 0) return;
            _numHintsLeft = value;
            if (value == 0)
            {
                this.DisableHintButton();
            }
            this.UpdateHintButtonText(_numHintsLeft);
        }
    }

    private void Awake()
    {
        _hintButton = GetComponent<Button>();
    }

    void Start()
    {
        Init();
    }

    private void OnEnable()
    {
        GameManager.OnTransitionToGameplay += Init;
        GameManager.OnTransitionToGameplay += DisableHintButton;
        GameManager.OnPuzzleTransitionEnd += EnableHintButton;
        _hintButton.onClick.AddListener(UseHint);
    }

    private void OnDisable()
    {
        GameManager.OnTransitionToGameplay -= Init;
        GameManager.OnTransitionToGameplay -= DisableHintButton;
        GameManager.OnPuzzleTransitionEnd -= EnableHintButton;
        _hintButton.onClick.RemoveListener(UseHint);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UseHint()
    {
        OnUsedHint?.Invoke();
        NumHintsLeft--;
        this.DisableHintButton();
    }

    public void EnableHintButton()
    {
        if (_numHintsLeft == 0) return;
        _hintButton.interactable = true;
    }
    public void DisableHintButton()
    {
        _hintButton.interactable = false;
    }

    public void UpdateHintButtonText(int hintsRemaining)
    {
        _hintButtonText.text =
            string.Format("Use Hint • {0}", hintsRemaining);
    }

    public void Init()
    {
        NumHintsLeft = _startingNumHints;
    }


}
