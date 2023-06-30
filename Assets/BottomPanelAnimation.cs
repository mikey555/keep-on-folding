using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static ExtensionMethods.TransformExtensions;

public class BottomPanelAnimation : CanvasAnimation
{
    [SerializeField] Vector3 _hidePos;
    [SerializeField] Vector3 _showPos;

    private void Awake()
    {

        _hidePos = _animatedElement.transform.localPosition;
        _showPos = _hidePos + 120 * Vector3.up;
    }


    private void OnEnable()
    {
        GameManager.OnGameOver += Hide;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= Hide;
    }
    public void Hide()
    {
        _animatedElement.DOLocalMove(_hidePos, 0.5f).SetEase(Ease.InSine);
    }

    public void Show()
    {
        _animatedElement.DOLocalMove(_showPos, 0.5f).SetEase(Ease.InSine);
    }
}

