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
    public static event Action OnTimeUp;
    protected const int MAX_TIME_ALLOWED_ON_CLOCK = 999;

    protected float _timeLeft;


    protected float TimeLeft
    {
        get { return _timeLeft; }
        set
        {
            if (value > MAX_TIME_ALLOWED_ON_CLOCK) _timeLeft = 999;
            _timeLeft = value;
        }
    }
    protected bool _isTimerActive;
    [SerializeField] TMP_Text timeLeftText;



    void Start()
    {
        Init();
    }

    protected void Init()
    {
        TimeLeft = _startingTimerDuration;
        this.SetTimeLeftText(TimeLeft);
        _isTimerActive = false;
    }

    // public void InitAndStart()
    // {
    //     Init();
    //     StartTimer();
    // }


    // Update is called once per frame
    protected virtual void Update()
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

    public void SetTimeLeftText(float timeLeft)
    {
        timeLeftText.text = Mathf.Ceil(timeLeft).ToString();
    }
}
