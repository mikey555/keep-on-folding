using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour
{
    PlayerInputActions _playerInputActions;
    public static event Action<OnSubmitEventArgs> OnSubmit;
    public static event Action<OnSkipEventArgs> OnSkip;

    void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    void Start()
    {
        GameManager.OnPuzzleTransitionStart += DisableAllActions;
        GameManager.OnPuzzleTransitionEnd += EnableAllActions;
        GameManager.OnGameOver += DisableAllActions;
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
    }


    public void ClearLastTypedLetter(InputAction.CallbackContext ctx)
    {
        GameManager.Instance.CurrentPuzzle.ClearLastTypedLetter();
    }

    public void ClearTypedLetters(InputAction.CallbackContext ctx)
    {
        GameManager.Instance.CurrentPuzzle.ClearTypedLetters();
    }

    public void Skip(InputAction.CallbackContext ctx)
    {
        var args = new OnSkipEventArgs();
        args.Puzzle = GameManager.Instance.CurrentPuzzle;
        OnSkip?.Invoke(args);
    }

    public void Scramble(InputAction.CallbackContext ctx)
    {
        GameManager.Instance.CurrentPuzzle.Scramble();
    }

    public void Submit(InputAction.CallbackContext ctx)
    {
        var puzzle = GameManager.Instance.CurrentPuzzle;
        if (puzzle.IsSubmissionValid())
        {
            var eventArgs = new OnSubmitEventArgs();
            eventArgs.Puzzle = GameManager.Instance.CurrentPuzzle;
            OnSubmit?.Invoke(eventArgs);


        }

    }

    public void OnTextInput(char ch)
    {
        GameManager.Instance.CurrentPuzzle.CheckForLetter(ch.ToString());
    }

    void EnableAllActions()
    {
        _playerInputActions.Enable();
    }

    void DisableAllActions()
    {
        _playerInputActions.Disable();
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