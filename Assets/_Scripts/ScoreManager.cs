using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] int numHintsLeft;
    [SerializeField] StreakTracker streakTracker;

    public int NumHintsLeft
    {
        get { return numHintsLeft; }
        set
        {
            if (value < 0) return;
            numHintsLeft = value;
            Debug.Log("[DEBUG] Hints left: " + value.ToString());
            if (value == 0)
            {
                UIManager.Instance.DisableHintButton();
            }
            else
            {
                UIManager.Instance.EnableHintButton();
            }
            UIManager.Instance.UpdateHintButtonText(NumHintsLeft);
        }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {


    }



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerSkips()
    {

        UIManager.Instance.ShowNumberChange(Constants.SKIP_TIME_PENALTY, isPenalty: true);
        streakTracker.RestartStreak();
    }

    public void PlayerPasses()
    {

        UIManager.Instance.ShowNumberChange(Constants.CORRECT_ANSWER_TIME_BONUS, isPenalty: false);
        streakTracker.IncreaseStreak();
    }

    public void UseHint()
    {
        var success = GameManager.Instance.UseHint();
        if (success) NumHintsLeft--;

    }





}








