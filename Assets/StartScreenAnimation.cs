using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartScreenAnimation : CanvasAnimation
{
    [SerializeField] protected Image _backgroundImage; // e.g., grey semi-transparent panel
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        GameManager.OnGoToStartScreen += EaseInFromRight;
    }

    private void OnDisable()
    {
        GameManager.OnGoToStartScreen -= EaseInFromRight;
    }

    public void EaseInFromRight()
    {
        _animatedElement.DOLocalMoveX(_canvasPos.x + 2000, 1f).SetEase(Ease.InCubic).From();
    }

    public Sequence EaseOutToLeft()
    {
        float duration = 1f;
        Sequence seq = DOTween.Sequence();
        seq.Append(_animatedElement.DOLocalMoveX(_canvasPos.x - 2000, duration).SetEase(Ease.OutCubic));

        seq.Join(_backgroundImage.DOColor(Color.clear, duration));
        return seq;
    }
}
