using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : Singleton<Timer>
{
    [SerializeField] float _startingGameDuration = 60f;
    [SerializeField] bool _unlimitedTime;
    public static event Action OnTimeUp;
    float _timeLeft;
    bool _isTimerActive;
    void Start()
    {
        _timeLeft = _startingGameDuration;
        _isTimerActive = false;
    }

    private void OnEnable()
    {
        PlayerActions.OnSubmit += AddTimeBonus;
        PlayerActions.OnSkip += AddTimePenalty;
        GameManager.OnGameplayStart += StartTimer;
    }

    private void OnDisable()
    {
        PlayerActions.OnSubmit -= AddTimeBonus;
        PlayerActions.OnSkip -= AddTimePenalty;
        GameManager.OnGameplayStart -= StartTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isTimerActive) return;
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UIManager.Instance.SetTimeLeft(_timeLeft);
            
        }
        else
        {
            OnTimeUp?.Invoke();
            _isTimerActive = false;
        }
    }

    public void AddTimePenalty(OnSkipEventArgs args)
    {
        _timeLeft -= Constants.SKIP_TIME_PENALTY;
    }

    public void AddTimeBonus(OnSubmitEventArgs args)
    {
        _timeLeft += Constants.CORRECT_ANSWER_TIME_BONUS;
    }

    public void StartTimer() {
        _isTimerActive = true;
    }
}
