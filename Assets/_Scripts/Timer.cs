using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    [SerializeField] float _startingTimerDuration = 60f;
    [SerializeField] bool _unlimitedTime;
    public static event Action OnTimeUp;
    const int MAX_TIME_ALLOWED_ON_CLOCK = 999;
    const int WARN_AT_TIME_REMAINING = 10;
    float _timeLeft;
    Image _image;

    float TimeLeft
    {
        get { return _timeLeft; }
        set
        {
            if (value > MAX_TIME_ALLOWED_ON_CLOCK) _timeLeft = 999;
            _timeLeft = value;
        }
    }
    bool _isTimerActive;
    [SerializeField] TMP_Text timeLeftText;
    private void Awake()
    {
        _image = GetComponent<Image>();

        GameManager.OnStartGameplay += Init;
        GameManager.OnStartGameplay += StartTimer;
        PlayerActions.OnSubmit += AddTimeBonus;
        PlayerActions.OnSkip += AddTimePenalty;


    }

    private void OnDestroy()
    {
        GameManager.OnStartGameplay += Init;
        GameManager.OnStartGameplay -= StartTimer;
        PlayerActions.OnSubmit -= AddTimeBonus;
        PlayerActions.OnSkip -= AddTimePenalty;


    }

    void Start()
    {

    }

    void Init()
    {
        TimeLeft = _startingTimerDuration;
        this.SetTimeLeftText(TimeLeft);
        _isTimerActive = false;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isTimerActive) return;
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            this.SetTimeLeftText(TimeLeft);

        }
        else
        {
            OnTimeUp?.Invoke();
            _isTimerActive = false;
        }
        // warning flashes
        if (TimeLeft < WARN_AT_TIME_REMAINING)
        {
            _image.DOColor(Color.red, 0.3f);
        }
        else
        {
            _image.DOColor(Color.white, 0.3f);
        }


    }

    public void AddTimePenalty(FinishTurnEventArgs args)
    {
        TimeLeft -= Constants.SKIP_TIME_PENALTY;

    }

    public void AddTimeBonus(FinishTurnEventArgs args)
    {
        TimeLeft += Constants.CORRECT_ANSWER_TIME_BONUS;
    }

    public void StartTimer()
    {
        _isTimerActive = true;
        Debug.Log("StartTimer");
    }

    public void SetTimeLeftText(float timeLeft)
    {
        timeLeftText.text = Mathf.Ceil(timeLeft).ToString();
    }
}
