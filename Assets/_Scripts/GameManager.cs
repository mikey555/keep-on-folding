using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : Singleton<GameManager>
{



    public enum GameState
    {
        StartScreen, TransitionToGameplay, Gameplay, GameOverScreen
    }

    GameState _gameState;
    [SerializeField] TransitionDirector _transitionDirector;
    public GameState FoldingGameState
    {
        get { return _gameState; }
    }

    public static event Action OnGoToStartScreen;
    public static event Action OnTransitionToGameplay;
    public static event Action OnStartGameplay;
    public static event Action OnGameOver;
    public static event Action OnPuzzleTransitionStart;
    public static event Action OnPuzzleTransitionEnd;

    [SerializeField] Timer _gameTimer;

    private void OnEnable()
    {
        PlayerActions.OnSubmit += PuzzleTransitionStart;
        PlayerActions.OnSkip += PuzzleTransitionStart;
        _gameTimer.OnTimeUp += GoToGameOverScreen;
    }

    private void OnDisable()
    {

        PlayerActions.OnSubmit -= PuzzleTransitionStart;
        PlayerActions.OnSkip -= PuzzleTransitionStart;
        _gameTimer.OnTimeUp -= GoToGameOverScreen;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GoToStartScreen();
    }

    public void GoToStartScreen()
    {
        _gameState = GameState.StartScreen;
        OnGoToStartScreen?.Invoke();
    }

    public void TransitionToGameplay()
    {

        if (_gameState == GameState.StartScreen)
            _transitionDirector.TransitionFromStartScreenToGameplay();
        if (_gameState == GameState.GameOverScreen)
            _transitionDirector.TransitionFromGameOverToGameplay();

        _gameState = GameState.TransitionToGameplay;
        OnTransitionToGameplay?.Invoke();
    }

    public void TransitionFromGameOverToGameplay()
    {

        _transitionDirector.TransitionFromGameOverToGameplay();
        _gameState = GameState.TransitionToGameplay;
        OnTransitionToGameplay?.Invoke();
    }

    public void StartGameplay()
    {
        _gameState = GameState.Gameplay;
        OnStartGameplay?.Invoke();
    }

    public void GoToGameOverScreen()
    {
        _gameState = GameState.GameOverScreen;
        OnGameOver?.Invoke();
    }

    public void Button_PlayAgainClicked()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartGameplay();
    }



    public void PuzzleTransitionStart(PlayerActionEventArgs args)
    {
        OnPuzzleTransitionStart?.Invoke();
    }

    public void PuzzleTransitionEnd(PlayerActionEventArgs args)
    {
        OnPuzzleTransitionEnd?.Invoke();
    }


}
