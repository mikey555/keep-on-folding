using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;


[RequireComponent(typeof(WordList))]
public class GameManager : Singleton<GameManager>
{

    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Transform _puzzleSpawnTransform;
    [SerializeField] Transform _puzzleParent;
    [SerializeField] PlayerInputActions _playerInputActions;



    static bool isGameOver;

    public enum GameState
    {
        Start, Gameplay, GameOver
    }

    GameState _gameState;
    public GameState CurrGameState
    {
        get { return _gameState; }
    }

    public static event Action OnGameStart;
    public static event Action OnGameplayStart;
    public static event Action OnGameOver;
    public static event Action OnPuzzleTransitionStart;
    public static event Action OnPuzzleTransitionEnd;


    [SerializeField] Puzzle _puzzlePrefab;


    WordList wordList;
    List<string[]> words;



    Puzzle _currentPuzzle;
    public Puzzle CurrentPuzzle
    {
        get { return _currentPuzzle; }
    }

    protected override void Awake()
    {
        base.Awake();

        wordList = GetComponent<WordList>();
        wordList.Init();
        words = wordList.Words;
    }

    // Start is called before the first frame update
    void Start()
    {


        isGameOver = false;
        _gameState = GameState.Gameplay;


        NextPuzzle();
    }

    public void GoToGameStart()
    {
        _gameState = GameState.Start;
        OnGameStart?.Invoke();
    }

    public void GoToGameplayStart()
    {
        _gameState = GameState.Gameplay;
        OnGameplayStart?.Invoke();
    }

    public void GoToGameOver()
    {
        _gameState = GameState.GameOver;
        GameObject.Destroy(_currentPuzzle.gameObject);
        OnGameOver?.Invoke();
    }

    public void RestartGameplay()
    {
        GoToGameplayStart();
    }

    // Update is called once per frame
    void Update()
    {



    }

    public string[] GetWordArray()
    {
        if (words.Count == 0)
        {
            // TODO: you win, no more words
        }
        var index = UnityEngine.Random.Range(0, words.Count);
        var wordArray = words[index];
        words.Remove(wordArray);
        Debug.Log(wordArray[0]);
        return wordArray;
    }



    public void ShowAnagrams(List<string> words)
    {
        var c1 = new HashSet<char>();
        c1.Add('A');
        c1.Add('B');
        c1.Add('C');
        var c2 = new HashSet<char>();
        c2.Add('A');
        c2.Add('B');
        c2.Add('D');
        Debug.Log("c1 == c2: " + c1.SetEquals(c2));

        var charArrayList = new List<(string, char[])>();
        foreach (var word in words)
        {
            Debug.Log("Word: " + word);
            char[] charArray = word.ToCharArray();
            Debug.Log(charArray.ToString());
            System.Array.Sort(charArray, Comparer<char>.Default);
            Debug.Log(charArray.ToString());

            foreach (var charArrayFromList in charArrayList)
            {
                if (charArray == charArrayFromList.Item2)
                {
                    Debug.Log(word + "/" + charArrayFromList.Item1);
                }
            }
            charArrayList.Add((word, charArray));

        }


    }

    public void NextPuzzle()
    {

        if (_gameState == GameState.GameOver) return;
        if (_currentPuzzle != null)
            UnityEngine.Object.Destroy(_currentPuzzle.gameObject);
        var next = Instantiate<Puzzle>(_puzzlePrefab, _puzzleSpawnTransform.position, Quaternion.identity, _puzzleParent);
        next.gameObject.SetActive(true);
        _currentPuzzle = next;

    }





    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool UseHint()
    {
        return CurrentPuzzle.ActivateHint();
    }

    public void PuzzleTransitionStart()
    {
        OnPuzzleTransitionStart?.Invoke();
    }

    public void PuzzleTransitionEnd()
    {
        OnPuzzleTransitionEnd?.Invoke();
    }

}
