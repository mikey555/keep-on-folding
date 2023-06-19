using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;



public class UIManager : Singleton<UIManager>
{
    
    


    



    [SerializeField] Canvas startScreenCanvas;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas bottomPanelCanvas;

    


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
        bottomPanelCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void StartGameplay()
    {
        startScreenCanvas.gameObject.SetActive(false);
        bottomPanelCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void GoToGameOverScreen()
    {
        startScreenCanvas.gameObject.SetActive(false);
        bottomPanelCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);

    }













}
