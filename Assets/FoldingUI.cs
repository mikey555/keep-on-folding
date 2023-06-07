using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;



public class FoldingUI : MonoBehaviour
{
    private static FoldingUI _instance;
    public static FoldingUI Instance { get => _instance; set => _instance = value; }
    [SerializeField] TMP_Text answerText;
    [SerializeField] Color defaultAnswerTextColor = Color.black;
    [SerializeField] TMP_Text timeLeftText;
    [SerializeField] RectTransform gameOverPanel;
    [SerializeField] TMP_Text streakLengthText;
    [SerializeField] Button hintButton;
    [SerializeField] Text numberChange;
    

    void Awake() {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    private void OnEnable() {
        ScoreManager.OnGameOver += OnGameOver;
    }

    private void OnDisable() {
        ScoreManager.OnGameOver -= OnGameOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevealAnswer(string word, Color color) {
        StartCoroutine(RevealAnswerCoroutine(word, color));
    }
    IEnumerator RevealAnswerCoroutine(string word, Color color) {
        
        answerText.text = word;
        answerText.color = color;
        var transparentColor = new Color(color.r, color.g, color.b, 0);
        
        Sequence seq = DOTween.Sequence();
        seq.Append(answerText.transform.DOMove(answerText.transform.position + Vector3.up, 1f))
            .Append(DOTween.To(()=> answerText.color, x=> answerText.color = x, transparentColor, 1).SetOptions(true));
        yield return seq.WaitForCompletion();
        answerText.text = "";
        answerText.color = defaultAnswerTextColor;        
    }

    public void HideAnswer() {
        answerText.text = "";
    }

    public void SetTypedLettersText(string str) {
        answerText.text = str;
    }

    public void OnGameOver() {
        gameOverPanel.gameObject.SetActive(true);
        timeLeftText.enabled = false;
    }

    public void SetTimeLeft(float timeLeft) {
        timeLeftText.text = Mathf.Ceil(timeLeft).ToString();
    }


    public void DisableHintButton() {
        if (!hintButton.IsInteractable()) return;
        hintButton.interactable = false;
    }

    public void EnableHintButton() {
        if (hintButton.IsInteractable()) return;
        hintButton.interactable = true;
    }

    public void UpdateHintButtonText(int hintsRemaining) {
        hintButton.GetComponentInChildren<TMP_Text>().text = 
            string.Format("Use Hint\n<b>{0}</b> Remaining", hintsRemaining);
    }

    public void ShowNumberChange(float val, bool isPenalty = false) {
        var numText = GameObject.Instantiate<Text>(numberChange, timeLeftText.transform);
        var signString = "";
        Color startColor;
        if (!isPenalty) {
            signString = "+";
            startColor = Color.green;
        }
        else {
            signString = "-";
            startColor = Color.red;
        }
        var endColor = new Color(startColor.r, startColor.b, startColor.g, 0);
        numText.color = startColor;
        numText.text = signString + val.ToString();
        numText.gameObject.SetActive(true);
        numText.transform.DOMoveY(numText.transform.position.y + 20, 2f);
        numText.DOColor(endColor, 2f).OnComplete(() => {
            GameObject.Destroy(numText);
        });
        
    }
    
    
}
