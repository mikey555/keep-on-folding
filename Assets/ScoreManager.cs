using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ScoreManager : MonoBehaviour
{
    static bool isGameOver;
    public static bool IsGameOver {
        get { return isGameOver; }
    }
    public static event Action OnGameOver;
    [SerializeField] float startingTimeLeft;
    

    [SerializeField] int numHintsLeft;
    [SerializeField] StreakTracker streakTracker;
    public int NumHintsLeft {
        get {return numHintsLeft;}
        set {
            if (value < 0) return;
            numHintsLeft = value;
            Debug.Log("[DEBUG] Hints left: " + value.ToString());
            if (value == 0) {
                FoldingUI.Instance.DisableHintButton();
            } else {
                FoldingUI.Instance.EnableHintButton();
            }
            FoldingUI.Instance.UpdateHintButtonText(NumHintsLeft);
        }
    } 
    

    float currTimeLeft;
    // Start is called before the first frame update
    void Start()
    {
        currTimeLeft = startingTimeLeft;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) {
            return;
        }
        currTimeLeft -= Time.deltaTime;
        FoldingUI.Instance.SetTimeLeft(currTimeLeft);
        if (currTimeLeft <= 0){
            OnGameOver?.Invoke();
            isGameOver = true;
        }
    }    

    public void PlayerSkips() {
        currTimeLeft -= Constants.SKIP_TIME_PENALTY;
        FoldingUI.Instance.ShowNumberChange(Constants.SKIP_TIME_PENALTY, isPenalty: true);
        streakTracker.RestartStreak();
    }

    public void PlayerPasses() {
        currTimeLeft += Constants.CORRECT_ANSWER_TIME_BONUS;
        FoldingUI.Instance.ShowNumberChange(Constants.CORRECT_ANSWER_TIME_BONUS, isPenalty: false);
        streakTracker.IncreaseStreak();
    }

    public void UseHint() {
        var success = GameManager.Instance.UseHint();
        if (success) NumHintsLeft--;

    }





}








