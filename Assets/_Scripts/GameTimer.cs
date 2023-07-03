using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameTimer : Timer
{
    Image _image;
    const int WARN_AT_TIME_REMAINING = 10;
    // Start is called before the first frame update
    private void Awake()
    {

        _image = GetComponent<Image>();

        GameManager.OnTransitionToGameplay += Init;
        GameManager.OnStartGameplay += StartTimer;
        PlayerActions.OnSubmit += AddTime;
        PlayerActions.OnSkip += SubtractTime;
    }

    private void OnDestroy()
    {
        GameManager.OnTransitionToGameplay -= Init;
        GameManager.OnStartGameplay -= StartTimer;
        PlayerActions.OnSubmit -= AddTime;
        PlayerActions.OnSkip -= SubtractTime;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!_isTimerActive) return;
        // warning flashes
        if (base.TimeLeft < WARN_AT_TIME_REMAINING)
        {
            _image.DOColor(Color.red, 0.3f);
        }
        else
        {
            _image.DOColor(Color.white, 0.3f);
        }
    }

    protected override void Init()
    {
        base.Init();
        _image.DOColor(Color.white, 0.3f);
    }
}
