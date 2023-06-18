using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float _startingTimerDuration = 60f;
    [SerializeField] bool _unlimitedTime;
    public static event Action OnTimeUp;
    float _timeLeft;
    bool _isTimerActive;
    [SerializeField] TMP_Text timeLeftText;
    private void Awake()
    {
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
        _timeLeft = _startingTimerDuration;
        this.SetTimeLeft(_timeLeft);
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
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            this.SetTimeLeft(_timeLeft);

        }
        else
        {
            OnTimeUp?.Invoke();
            _isTimerActive = false;
        }
    }

    public void AddTimePenalty(FinishTurnEventArgs args)
    {
        _timeLeft -= Constants.SKIP_TIME_PENALTY;

    }

    public void AddTimeBonus(FinishTurnEventArgs args)
    {
        _timeLeft += Constants.CORRECT_ANSWER_TIME_BONUS;
    }

    public void StartTimer()
    {
        _isTimerActive = true;
        Debug.Log("StartTimer");
    }

    public void SetTimeLeft(float timeLeft)
    {
        timeLeftText.text = Mathf.Ceil(timeLeft).ToString();
    }
}
