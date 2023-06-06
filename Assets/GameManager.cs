using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(WordList))]
public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get => _instance; set => _instance = value; }

    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Transform spawnPoint;




    public GameObject PuzzlePrefab;

    WordList wordList;
    List<string[]> words;
    

    Puzzle _currentPuzzle;
    public Puzzle CurrentPuzzle {
        get { return _currentPuzzle; }
    }

    [SerializeField] FoldingUI ui;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        wordList = GetComponent<WordList>();

    }

    // Start is called before the first frame update
    void Start()
    {
        words = wordList.Words;
        
        NextPuzzle();
    }

   // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            _currentPuzzle.CheckForLetter("A");
            
        } else if (Input.GetKeyDown(KeyCode.B))
        {
            _currentPuzzle.CheckForLetter("B");
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            _currentPuzzle.CheckForLetter("C");
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            _currentPuzzle.CheckForLetter("D");
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            _currentPuzzle.CheckForLetter("E");
        } else if (Input.GetKeyDown(KeyCode.F))
        {
            _currentPuzzle.CheckForLetter("F");
        }

        else if (Input.GetKeyDown(KeyCode.G))
        {
            _currentPuzzle.CheckForLetter("G");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            _currentPuzzle.CheckForLetter("H");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            _currentPuzzle.CheckForLetter("I");
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            _currentPuzzle.CheckForLetter("J");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            _currentPuzzle.CheckForLetter("K");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            _currentPuzzle.CheckForLetter("L");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            _currentPuzzle.CheckForLetter("M");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            _currentPuzzle.CheckForLetter("N");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            _currentPuzzle.CheckForLetter("O");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            _currentPuzzle.CheckForLetter("P");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            _currentPuzzle.CheckForLetter("Q");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            _currentPuzzle.CheckForLetter("R");
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            _currentPuzzle.CheckForLetter("S");
        }

        else if (Input.GetKeyDown(KeyCode.T))
        {
            _currentPuzzle.CheckForLetter("T");
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            _currentPuzzle.CheckForLetter("U");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            _currentPuzzle.CheckForLetter("V");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _currentPuzzle.CheckForLetter("W");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            _currentPuzzle.CheckForLetter("X");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            _currentPuzzle.CheckForLetter("Y");
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            _currentPuzzle.CheckForLetter("Z");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            _currentPuzzle.ClearTypedLetters();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _currentPuzzle.ClearLastTypedLetter();
        }
        else if (Input.GetKeyDown(KeyCode.Slash))
        {
            _currentPuzzle.Scramble();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && _currentPuzzle.LetterCount == 6)
        {
            
            if (GameManager.IsWordValid(_currentPuzzle.TypedLetters, _currentPuzzle.WordPossibilities))
            {
                _currentPuzzle.Pass();
                FoldingUI.Instance.RevealAnswer(_currentPuzzle.TypedLetters, Color.HSVToRGB(0.33f, 0.8f, 0.8f));
                scoreManager.PlayerPasses();
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentPuzzle.Skip();
            FoldingUI.Instance.RevealAnswer(_currentPuzzle.WordPossibilities[0], Color.HSVToRGB(1f, 1f, 0.8f));
            scoreManager.PlayerSkips();
            
        }

        
    }

    public string[] GetWordArray()
    {
        if (words.Count == 0) {
            // TODO: you win, no more words
        }
        var index = Random.Range(0, words.Count);
        var wordArray = words[index];
        words.Remove(wordArray);
        Debug.Log(wordArray[0]);
        return wordArray;
    }

 

    public void ShowAnagrams(List<string> words) {
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
        foreach (var word in words) {
            Debug.Log("Word: " + word);
            char[] charArray = word.ToCharArray();
            Debug.Log(charArray.ToString());
            System.Array.Sort(charArray, Comparer<char>.Default);
            Debug.Log(charArray.ToString());
            
            foreach (var charArrayFromList in charArrayList) {
                if (charArray == charArrayFromList.Item2){
                    Debug.Log(word + "/" + charArrayFromList.Item1);
                }
            }
            charArrayList.Add((word, charArray));

        }
        
        
    }

    public void NextPuzzle()
    {
        
        if (ScoreManager.IsGameOver) return;
        var next = Instantiate(PuzzlePrefab);
        next.gameObject.SetActive(true);
        _currentPuzzle = next.GetComponent<Puzzle>();

    }

    

    public static bool IsWordValid(string wordEntered,  string[] words) {
        foreach (var word in words) {
            if (word.ToUpper() == wordEntered.ToUpper()) {
                return true;
            }
        }
        return false;
    }

    public void OnPlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool UseHint() {
        return CurrentPuzzle.ActivateHint();
    }
    
}
