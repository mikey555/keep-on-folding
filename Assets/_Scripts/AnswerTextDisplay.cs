using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class AnswerTextDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    // everytime there's a new puzzle, subscribe to its AnswerModified
    TMP_Text answerText;
    Puzzle _currentPuzzle;
    [SerializeField] Color _correctAnswerColor = Color.HSVToRGB(0.33f, 0.8f, 0.8f);
    [SerializeField] Color _skipAnswerColor = Color.HSVToRGB(1f, 1f, 0.8f);
    [SerializeField] Color _defaultAnswerTextColor = Color.white;
    Sequence _fadeOutTween;

    void Awake()
    {
        answerText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        PuzzleSpawner.OnNewPuzzleSpawned += PuzzleSpawner_OnNewPuzzleSpawned;
        PlayerActions.OnSubmit += RevealCorrectAnswer;
        PlayerActions.OnSkip += RevealSkippedAnswer;
    }

    private void OnDisable()
    {
        PlayerActions.OnSubmit -= RevealCorrectAnswer;
        PlayerActions.OnSkip -= RevealSkippedAnswer;
    }

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

        if (_fadeOutTween != null && _fadeOutTween.IsActive())
        {
            _fadeOutTween.Kill();
        }
        _fadeOutTween = DOTween.Sequence()
            .Append(answerText.transform.DOMove(answerText.transform.position + Vector3.up, 1f))
            .Append(DOTween.To(() => answerText.color, x => answerText.color = x, Color.clear, 1).SetOptions(true))
            .OnComplete(() =>
            {
                answerText.text = "";
                answerText.color = _defaultAnswerTextColor;
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

    public void PuzzleSpawner_OnNewPuzzleSpawned(Puzzle puzzle)
    {
        if (_currentPuzzle != null)
        {
            _currentPuzzle.OnAnswerChanged -= SetTypedLettersText;
        }
        _currentPuzzle = puzzle;
        _currentPuzzle.OnAnswerChanged += SetTypedLettersText;
    }
}
