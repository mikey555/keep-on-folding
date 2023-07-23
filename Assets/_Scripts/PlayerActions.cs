using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour, IGetNewPuzzle
{
    PlayerInputActions _playerInputActions;
    public static event Action OnSubmit;
    public static event Action OnSkip;

    Puzzle _currentPuzzle;
    public Puzzle CurrentPuzzle
    {
        get { return _currentPuzzle; }
    }

    void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    void Start()
    {
        DisableAllActions();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        EnableAllActions();
        _playerInputActions.Player.Clear.performed += ClearTypedLetters;
        _playerInputActions.Player.Skip.performed += Skip;
        _playerInputActions.Player.Backspace.performed += ClearLastTypedLetter;
        _playerInputActions.Player.Scramble.performed += Scramble;
        _playerInputActions.Player.Submit.performed += Submit;
        Keyboard.current.onTextInput += OnTextInput;

        GameManager.OnTransitionToGameplay += DisableAllActions;
        GameManager.OnStartGameplay += EnableAllActions;
        PuzzleSpawner.OnNewPuzzleSpawned += GetNewPuzzle;
        GameManager.OnPuzzleTransitionStart += DisableAllActions;
        GameManager.OnPuzzleTransitionEnd += EnableAllActions;
        GameManager.OnGameOver += DisableAllActions;

    }

    private void OnDisable()
    {
        DisableAllActions();
        _playerInputActions.Player.Clear.performed -= ClearTypedLetters;
        _playerInputActions.Player.Skip.performed -= Skip;
        _playerInputActions.Player.Backspace.performed -= ClearLastTypedLetter;
        _playerInputActions.Player.Scramble.performed -= Scramble;
        _playerInputActions.Player.Submit.performed -= Submit;
        Keyboard.current.onTextInput -= OnTextInput;

        GameManager.OnTransitionToGameplay -= DisableAllActions;
        GameManager.OnStartGameplay -= EnableAllActions;
        PuzzleSpawner.OnNewPuzzleSpawned -= GetNewPuzzle;
        GameManager.OnPuzzleTransitionStart -= DisableAllActions;
        GameManager.OnPuzzleTransitionEnd -= EnableAllActions;
        GameManager.OnGameOver -= DisableAllActions;
    }


    public void ClearLastTypedLetter(InputAction.CallbackContext ctx)
    {
        _currentPuzzle.ClearLastTypedLetter();
    }

    public void ClearTypedLetters(InputAction.CallbackContext ctx)
    {
        _currentPuzzle.ClearTypedLetters();
    }

    public void Skip(InputAction.CallbackContext ctx)
    {
        var args = new FinishTurnEventArgs();
        args.Puzzle = _currentPuzzle;
        OnSkip?.Invoke();
    }

    public void Scramble(InputAction.CallbackContext ctx)
    {
        _currentPuzzle.Scramble();
    }

    public void Submit(InputAction.CallbackContext ctx)
    {

        if (_currentPuzzle.IsSubmissionValid())
        {
            var args = new FinishTurnEventArgs();
            args.Puzzle = _currentPuzzle;
            OnSubmit?.Invoke();


        }

    }

    public void OnTextInput(char ch)
    {
        _currentPuzzle.CheckForLetter(ch.ToString());
    }

    void EnableAllActions()
    {
        _playerInputActions.Enable();
        Keyboard.current.onTextInput += OnTextInput;
    }

    void DisableAllActions()
    {
        _playerInputActions.Disable();
        Keyboard.current.onTextInput -= OnTextInput;

        Debug.Log("DisableAllActions()");
    }

    public void GetNewPuzzle(Puzzle puzzle)
    {
        _currentPuzzle = puzzle;
    }

}

public class PlayerActionEventArgs : EventArgs { }

public class FinishTurnEventArgs : PlayerActionEventArgs
{
    public Puzzle Puzzle;
}

