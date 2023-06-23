using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static ExtensionMethods.TransformExtensions;

public class ModalScreenAnimation : CanvasAnimation
{
    [SerializeField] GameObject _startScreenModal;
    [SerializeField] GameObject _gameOverModal;

    GameObject _modalLayer;
    public GameObject ModalLayer
    {
        get { return _modalLayer; }
    }
    [SerializeField] Image _backgroundLayer; // e.g., grey semi-transparent panel
    public Image BackgroundLayer
    {
        get { return _backgroundLayer; }
    }



    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        GameManager.OnGoToStartScreen += StartScreenModalIn;
        GameManager.OnGameOver += GameOverModalIn;
    }

    private void OnDisable()
    {
        GameManager.OnGoToStartScreen -= StartScreenModalIn;
        GameManager.OnGameOver -= GameOverModalIn;
    }

    void EaseInFromRight(GameObject modal)
    {
        float duration = 0.5f;
        modal.SetActive(true);
        modal.transform.SetLocalX(1000f);
        _backgroundLayer.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();
        seq.Append(modal.transform.DOLocalMoveX(0, duration).SetEase(Ease.InCubic))
            .Join(_backgroundLayer.DOColor(Color.clear, duration));



    }

    // Director is doing this now
    void EaseOutToLeft(GameObject modal)
    {
        float duration = 0.5f;

        Sequence seq = DOTween.Sequence();
        seq.Append(modal.transform.DOLocalMoveX(-1000, duration).SetEase(Ease.OutCubic))
            .Join(_backgroundLayer.DOColor(Color.clear, duration))
            .AppendCallback(() =>
            {
                modal.SetActive(false);
                _backgroundLayer.gameObject.SetActive(false);
            });
    }

    public void StartScreenModalIn()
    {
        EaseInFromRight(_startScreenModal);
    }

    public void GameOverModalIn()
    {
        EaseInFromRight(_gameOverModal);
    }
}
