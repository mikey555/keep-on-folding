using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Timers;

public class CountdownClicker : Timer
{
    
    private void Awake()
    {
        // base._timeLeftText = GetComponent<TMP_Text>();
        // _timer = new System.Timers.Timer(1000); // elapse each second
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        
        // TODO: Seeems like this event never was invoked
        // GameManager.OnGameOver += Restart;

    }

    private void OnDisable()
    {
        // GameManager.OnGameOver -= Restart;
    }

    


    



  
}
