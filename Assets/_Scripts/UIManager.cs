using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{

    [SerializeField] ModalScreenAnimation _modalAnim;
    [SerializeField] Canvas gameCanvas;

    [SerializeField] Canvas bottomPanelCanvas;

    // public static event Action OnStartScreenTransitionOut_Complete;


    private void OnEnable()
    {
        GameManager.OnGoToStartScreen += GoToStartScreen;
        GameManager.OnStartGameplay += StartGameplay;
        GameManager.OnGameOver += GoToGameOverScreen;
    }

    private void OnDisable()
    {
        GameManager.OnGoToStartScreen -= GoToStartScreen;
        GameManager.OnStartGameplay -= StartGameplay;
        GameManager.OnGameOver -= GoToGameOverScreen;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void GoToStartScreen()
    {
        _modalAnim.StartScreenModalIn();
    }


    public void StartGameplay()
    {

    }

    public void GoToGameOverScreen()
    {
        _modalAnim.GameOverModalIn();

    }













}
