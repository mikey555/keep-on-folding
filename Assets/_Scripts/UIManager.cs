using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{

    [SerializeField] Canvas startScreenCanvas;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas bottomPanelCanvas;
    [SerializeField] Button _startGameButton;
    [SerializeField] Button _restartGameButton;

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
        startScreenCanvas.gameObject.SetActive(true);
        // bottomPanelCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
    }


    public void StartGameplay()
    {
        gameOverCanvas.gameObject.SetActive(false);

    }

    public void GoToGameOverScreen()
    {
        startScreenCanvas.gameObject.SetActive(false);
        // bottomPanelCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);

    }













}
