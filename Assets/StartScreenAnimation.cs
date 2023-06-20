using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartScreenAnimation : CanvasAnimation
{
    [SerializeField] protected Image _backgroundImage; // e.g., grey semi-transparent panel
    public static event Action OnStartScreenTransitionOut_Complete;
    protected override void Awake()
    {
        base.Awake();
        _animatedElement.position = new Vector3(
            _canvasPos.x + _animatedElement.position.x + 1000,
            _animatedElement.position.y,
            _animatedElement.position.z
        );
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
        base._animatedElement.DOMoveX(_canvasPos.x + 0, 1f).SetEase(Ease.InCubic);
    }

    public Sequence EaseOutToLeft()
    {
        float duration = 1f;
        Sequence seq = DOTween.Sequence();
        seq.Append(_animatedElement.DOMoveX(_canvasPos.x - 1000, duration).SetEase(Ease.OutCubic));
        seq.Join(_backgroundImage.DOColor(Color.clear, duration));
        return seq;
    }
}
