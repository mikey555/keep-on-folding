using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HintTracker : MonoBehaviour
{
    [SerializeField] Button _hintButton;
    public static event Action OnUsedHint;
    [SerializeField] int _numHintsLeft = 5;
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

    }

    private void OnEnable()
    {
        GameManager.OnPuzzleTransitionEnd += EnableHintButton;
        _hintButton.onClick.AddListener(UseHint);
    }

    private void OnDisable()
    {
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
        _hintButton.GetComponentInChildren<TMP_Text>().text =
            string.Format("Use Hint • {0}", hintsRemaining);
    }


}
