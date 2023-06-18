using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;



public class UIManager : Singleton<UIManager>
{
    [SerializeField] TMP_Text answerText;
    [SerializeField] Color defaultAnswerTextColor = Color.black;


    [SerializeField] TMP_Text streakLengthText;



    [SerializeField] Canvas startScreenCanvas;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas bottomPanelCanvas;

    [SerializeField] Color _correctAnswerColor = Color.HSVToRGB(0.33f, 0.8f, 0.8f);
    [SerializeField] Color _skipAnswerColor = Color.HSVToRGB(1f, 1f, 0.8f);


    private void OnEnable()
    {
        GameManager.OnGoToStartScreen += GoToStartScreen;
        GameManager.OnStartGameplay += StartGameplay;
        GameManager.OnGameOver += GoToGameOverScreen;
        PlayerActions.OnSubmit += RevealCorrectAnswer;
        PlayerActions.OnSkip += RevealSkippedAnswer;



    }

    private void OnDisable()
    {
        GameManager.OnGoToStartScreen -= GoToStartScreen;
        GameManager.OnStartGameplay -= StartGameplay;
        GameManager.OnGameOver -= GoToGameOverScreen;
        PlayerActions.OnSubmit -= RevealCorrectAnswer;
        PlayerActions.OnSkip -= RevealSkippedAnswer;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RevealAnswer(string word, bool isCorrect)
    {

        answerText.text = word;
        answerText.color = _skipAnswerColor;
        if (isCorrect) answerText.color = _correctAnswerColor;
        var transparentColor = new Color(answerText.color.r, answerText.color.g, answerText.color.b, 0);

        Sequence seq = DOTween.Sequence();
        seq.Append(answerText.transform.DOMove(answerText.transform.position + Vector3.up, 1f))
            .Append(DOTween.To(() => answerText.color, x => answerText.color = x, transparentColor, 1).SetOptions(true))
            .OnComplete(() =>
            {
                answerText.text = "";
                answerText.color = defaultAnswerTextColor;
            });
    }

    public void RevealCorrectAnswer(FinishTurnEventArgs args)
    {
        RevealAnswer(args.Puzzle.TypedLetters, true);
    }

    public void RevealSkippedAnswer(FinishTurnEventArgs args)
    {
        RevealAnswer(args.Puzzle.WordPossibilities[0], false);
    }


    public void HideAnswer()
    {
        answerText.text = "";
    }

    public void SetTypedLettersText(string str)
    {
        answerText.text = str;
    }

    public void GoToStartScreen()
    {
        startScreenCanvas.gameObject.SetActive(true);
        bottomPanelCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void StartGameplay()
    {
        startScreenCanvas.gameObject.SetActive(false);
        bottomPanelCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void GoToGameOverScreen()
    {
        startScreenCanvas.gameObject.SetActive(false);
        bottomPanelCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);

    }













}
