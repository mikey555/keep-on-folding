using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StreakTracker : MonoBehaviour
{
    // Start is called before the first frame update


    TMP_Text text;

    StreakAnimation streakAnim;


    [SerializeField] int _streakLength;
    [SerializeField] int onFireAt;
    public int StreakLength
    {
        get { return _streakLength; }
        set
        {
            _streakLength = value;
            if (value >= onFireAt)
            {
                streakAnim.EnableFire();
                AudioSystem.Instance.PlayFlameSound();
            }
            else if (value == 0)
            {
                streakAnim.DisableFire();
            }
            text.text = StreakLength.ToString();
        }
    }

    void Awake()
    {

        text = GetComponentInChildren<TMP_Text>();
        streakAnim = GetComponent<StreakAnimation>();
    }

    void Start()
    {
        StreakLength = 0;
    }

    private void OnEnable() {
        PlayerActions.OnSubmit += IncreaseStreak;
        PlayerActions.OnSkip += RestartStreak;
    }

    private void OnDisable() {
        PlayerActions.OnSubmit -= IncreaseStreak;
        PlayerActions.OnSkip -= RestartStreak;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseStreak(OnSubmitEventArgs args)
    {
        StreakLength++;
    }

    public void RestartStreak(OnSkipEventArgs args)
    {
        StreakLength = 0;
    }








}
