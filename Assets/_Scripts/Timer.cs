using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    [SerializeField] protected float _startingTimerDuration = 60f;
    [SerializeField] protected bool _unlimitedTime;
    public event Action OnTimeUp;
    protected const int MAX_TIME_ALLOWED_ON_CLOCK = 999;

    protected float _timeLeft;


    public float TimeLeft
    {
        get { return _timeLeft; }
        protected set
        {
            if (value > MAX_TIME_ALLOWED_ON_CLOCK) _timeLeft = 999;
            _timeLeft = value;
        }
    }
    protected bool _isTimerActive;
    [SerializeField] protected TMP_Text _timeLeftText;



    void Start()
    {
        SetTimeLeftText(_startingTimerDuration);
    }

    protected void Init()
    {
        TimeLeft = _startingTimerDuration;
        this.SetTimeLeftText(TimeLeft);
        _isTimerActive = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!_isTimerActive || _unlimitedTime) return;
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
    }

    public void Restart()
    {
        Init();
    }

    public void SubtractTime(FinishTurnEventArgs args)
    {
        TimeLeft -= Constants.SKIP_TIME_PENALTY;
    }

    public void AddTime(FinishTurnEventArgs args)
    {
        TimeLeft += Constants.CORRECT_ANSWER_TIME_BONUS;
    }

    public void StartTimer()
    {
        _isTimerActive = true;
    }

    public void InitAndStart()
    {
        Init();
        StartTimer();
    }

    public void SetTimeLeftText(float timeLeft)
    {
        _timeLeftText.text = Mathf.Ceil(timeLeft).ToString();
    }
}
