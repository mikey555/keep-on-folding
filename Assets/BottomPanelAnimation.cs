using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BottomPanelAnimation : CanvasAnimation
{

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
        _animatedElement.DOLocalMoveY(_animatedElement.localPosition.y - 200, 1f).SetEase(Ease.InCubic);
    }


}
