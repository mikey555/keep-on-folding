using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : Singleton<GameManager>
{

    [SerializeField] ScoreManager scoreManager;

    [SerializeField] PlayerInputActions _playerInputActions;





    public enum GameState
    {
        Start, Gameplay, GameOver
    }

    GameState _gameState;
    public GameState FoldingGameState
    {
        get { return _gameState; }
    }

    public static event Action OnGameStart;
    public static event Action OnGameplayStart;
    public static event Action OnGameOver;
    public static event Action OnPuzzleTransitionStart;
    public static event Action OnPuzzleTransitionEnd;











    private void OnEnable()
    {
        PlayerActions.OnSubmit += PuzzleTransitionStart;
        PlayerActions.OnSkip += PuzzleTransitionStart;
        Timer.OnTimeUp += GoToGameOver;
    }

    private void OnDisable()
    {
        PlayerActions.OnSubmit -= PuzzleTransitionStart;
        PlayerActions.OnSkip -= PuzzleTransitionStart;
        Timer.OnTimeUp -= GoToGameOver;
    }

    // Start is called before the first frame update
    void Start()
    {



        this.GoToGameplay();



    }

    public void GoToGameStart()
    {
        _gameState = GameState.Start;
        OnGameStart?.Invoke();
    }

    public void GoToGameplay()
    {
        _gameState = GameState.Gameplay;
        OnGameplayStart?.Invoke();
    }

    public void GoToGameOver()
    {
        if (_gameState != GameState.GameOver) return;
        _gameState = GameState.GameOver;
        OnGameOver?.Invoke();
    }

    public void RestartGameplay()
    {
        GoToGameplay();
    }



    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
