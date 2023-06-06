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
    

    [SerializeField] int streakLength;
    public int StreakLength {
        get { return streakLength;}
        set { 
            
            streakLength = value;
            streakAnim.UpdateStreak(streakLength);
            text.text = StreakLength.ToString();
        }
    }

    void Awake() {
        
        text = GetComponentInChildren<TMP_Text>();
        streakAnim = GetComponent<StreakAnimation>();
    }

    void Start()
    {
        StreakLength = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void IncreaseStreak() {
        StreakLength++;
    }

    public void RestartStreak() {
        StreakLength = 0;
    }

    

    

    
}
