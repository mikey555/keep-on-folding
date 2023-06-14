using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : Singleton<Timer>
{
    [SerializeField] float _startingGameDuration = 60f;
    [SerializeField] bool _unlimitedTime;
    float _timeLeft;
    void Start()
    {
        _timeLeft = _startingGameDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UIManager.Instance.SetTimeLeft(_timeLeft);
        }
        else if (GameManager.Instance.CurrGameState != GameManager.GameState.GameOver)
        {
            GameManager.Instance.GoToGameOver();
        }
    }

    public void PlayerSkips()
    {
        _timeLeft -= Constants.SKIP_TIME_PENALTY;
    }

    public void PlayerPasses()
    {
        _timeLeft += Constants.CORRECT_ANSWER_TIME_BONUS;
    }
}
