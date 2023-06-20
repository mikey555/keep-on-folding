using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static ExtensionMethods.TransformExtensions;

public class BottomPanelAnimation : CanvasAnimation
{
    protected override void Awake()
    {
        base.Awake();
        // _animatedElement.transform.SetY(-200);
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        // GameManager.OnStartGameplay += BottomPanelTransitionIn;
    }

    private void OnDisable()
    {
        // GameManager.OnStartGameplay -= BottomPanelTransitionIn;
    }

    public Sequence BottomPanelTransitionIn()
    {
        _canvas.gameObject.SetActive(true);
        var seq = DOTween.Sequence();
        var tween = _animatedElement.DOLocalMoveY(_animatedElement.localPosition.y - 100, 0.3f).From();
        seq.Append(tween);
        return seq;
    }
}
