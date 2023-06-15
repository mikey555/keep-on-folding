using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour, IGetNewPuzzle
{
    PlayerInputActions _playerInputActions;
    public static event Action<OnSubmitEventArgs> OnSubmit;
    public static event Action<OnSkipEventArgs> OnSkip;

    Puzzle _currentPuzzle;

    void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    void Start()
    {

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
        var args = new OnSkipEventArgs();
        args.Puzzle = _currentPuzzle;
        OnSkip?.Invoke(args);
    }

    public void Scramble(InputAction.CallbackContext ctx)
    {
        _currentPuzzle.Scramble();
    }

    public void Submit(InputAction.CallbackContext ctx)
    {

        if (_currentPuzzle.IsSubmissionValid())
        {
            var eventArgs = new OnSubmitEventArgs();
            eventArgs.Puzzle = _currentPuzzle;
            OnSubmit?.Invoke(eventArgs);


        }

    }

    public void OnTextInput(char ch)
    {
        _currentPuzzle.CheckForLetter(ch.ToString());
    }

    void EnableAllActions()
    {
        _playerInputActions.Enable();
    }

    void DisableAllActions()
    {
        _playerInputActions.Disable();
    }

    public void GetNewPuzzle(Puzzle puzzle)
    {
        _currentPuzzle = puzzle;
    }

}

public class PlayerActionEventArgs : EventArgs { }

public class OnSkipEventArgs : PlayerActionEventArgs
{
    public Puzzle Puzzle;
}

public class OnSubmitEventArgs : PlayerActionEventArgs
{
    public Puzzle Puzzle;
}