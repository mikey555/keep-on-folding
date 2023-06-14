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
    [SerializeField] TMP_Text timeLeftText;

    [SerializeField] TMP_Text streakLengthText;
    
    [SerializeField] Text numberChange;

    [SerializeField] Canvas startScreenCanvas;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas bottomPanelCanvas;

    [SerializeField] Color _correctAnswerColor = Color.HSVToRGB(0.33f, 0.8f, 0.8f);
    [SerializeField] Color _skipAnswerColor = Color.HSVToRGB(1f, 1f, 0.8f);


    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
        PlayerActions.OnSubmit += RevealCorrectAnswer;
        PlayerActions.OnSkip += RevealSkippedAnswer;
        PlayerActions.OnSubmit += ShowBonusTimeModification;
        PlayerActions.OnSkip += ShowPenaltyTimeModification;

    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
        PlayerActions.OnSubmit -= RevealCorrectAnswer;
        PlayerActions.OnSkip -= RevealSkippedAnswer;
        PlayerActions.OnSubmit -= ShowBonusTimeModification;
        PlayerActions.OnSkip -= ShowPenaltyTimeModification;
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

    public void RevealCorrectAnswer(OnSubmitEventArgs args)
    {
        RevealAnswer(args.Puzzle.TypedLetters, true);
    }

    public void RevealSkippedAnswer(OnSkipEventArgs args)
    {
        RevealAnswer(args.Puzzle.TypedLetters, false);
    }


    public void HideAnswer()
    {
        answerText.text = "";
    }

    public void SetTypedLettersText(string str)
    {
        answerText.text = str;
    }

    public void OnGameStart()
    {
        startScreenCanvas.gameObject.SetActive(true);
        bottomPanelCanvas.gameObject.SetActive(false);
    }

    public void OnGameplayStart()
    {
        startScreenCanvas.gameObject.SetActive(false);
        bottomPanelCanvas.gameObject.SetActive(true);
    }

    public void OnGameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        bottomPanelCanvas.gameObject.SetActive(false);

    }

    public void SetTimeLeft(float timeLeft)
    {
        timeLeftText.text = Mathf.Ceil(timeLeft).ToString();
    }


    

    public void ShowTimeModification(float val, bool isPenalty = false)
    {
        var numText = GameObject.Instantiate<Text>(numberChange, timeLeftText.transform);
        var signString = "";
        Color startColor;
        if (!isPenalty)
        {
            signString = "+";
            startColor = Color.green;
        }
        else
        {
            signString = "-";
            startColor = Color.red;
        }
        var endColor = new Color(startColor.r, startColor.b, startColor.g, 0);
        numText.color = startColor;
        numText.text = signString + val.ToString();
        numText.gameObject.SetActive(true);
        Sequence fadeOut = DOTween.Sequence();
        fadeOut
            .Append(numText.transform.DOMoveY(numText.transform.position.y + 20, 1f))
            .Join(numText.DOColor(endColor, 2f))
            .OnComplete(() =>
            {
                GameObject.Destroy(numText);
            });
    }

    public void ShowBonusTimeModification(OnSubmitEventArgs args) {
        ShowTimeModification(Constants.CORRECT_ANSWER_TIME_BONUS, false);
    }

    public void ShowPenaltyTimeModification(OnSkipEventArgs args) {
        ShowTimeModification(Constants.SKIP_TIME_PENALTY, true);
    }






}
