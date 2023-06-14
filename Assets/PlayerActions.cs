using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    PlayerInputActions _playerInputActions;

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

    void EnableAllActions()
    {
        _playerInputActions.Enable();
    }

    void DisableAllActions()
    {
        _playerInputActions.Disable();
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
        GameManager.Instance.CurrentPuzzle.Skip();
    }

    public void Scramble(InputAction.CallbackContext ctx)
    {
        GameManager.Instance.CurrentPuzzle.Scramble();
    }

    public void Submit(InputAction.CallbackContext ctx)
    {
        GameManager.Instance.CurrentPuzzle.Submit();
    }

    public void OnTextInput(char ch)
    {
        GameManager.Instance.CurrentPuzzle.OnTextInput(ch);
    }

}
