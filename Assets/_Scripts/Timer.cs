using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] protected float _startingTimerDuration = 60f;
    [SerializeField] protected bool _unlimitedTime;
    public event Action OnTimeUp;
    protected const int MAX_TIME_ALLOWED_ON_CLOCK = 999;

    public enum TimeUpTextBehavior { ShowZero, ShowString, HideText }
    [SerializeField] TimeUpTextBehavior _timeUpTextBehavior;
    [SerializeField] string _timeUpText;

    protected float _timeLeft;

    public float TimeLeft
    {
        get { return _timeLeft; }
        protected set
        {
            if (value > MAX_TIME_ALLOWED_ON_CLOCK) _timeLeft = MAX_TIME_ALLOWED_ON_CLOCK;
            _timeLeft = value;
        }
    }
    protected bool _isTimerActive;
    [SerializeField] protected TMP_Text _timeLeftText;



    void Start()
    {
        SetTimeLeftText(_startingTimerDuration);
        ClearText();
    }

    protected virtual void Init()
    {

        TimeLeft = _startingTimerDuration;
        this.SetTimeLeftText(TimeLeft);
        _isTimerActive = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!_isTimerActive || _unlimitedTime) return;
        TimeLeft -= Time.deltaTime;
        if (TimeLeft > 0)
        {
            this.SetTimeLeftText(TimeLeft);
        }
        else
        {
            OnTimeUp?.Invoke();
            _isTimerActive = false;
            if (_timeUpTextBehavior == TimeUpTextBehavior.HideText) ClearText();
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

    public void InitAndStart()
    {
        Init();
        StartTimer();
    }

    public void ClearText() { _timeLeftText.text = ""; }

    public void SetTimeLeftText(float timeLeft)
    {
        var str = Mathf.Ceil(timeLeft).ToString();
        // if (_hideTimeOnTimeUp && timeLeft <= 0) return; // takes an extra frame for gameobject to inactivate
        _timeLeftText.text = str;
    }
}
