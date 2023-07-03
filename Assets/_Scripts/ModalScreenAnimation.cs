using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static ExtensionMethods.TransformExtensions;

public class ModalScreenAnimation : MonoBehaviour
{

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    public Sequence EaseInFromRight()
    {
        var duration = 0.3f;
        gameObject.SetActive(true);
        transform.SetLocalX(1000f);

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveX(0, duration).SetEase(Ease.InSine));
        return seq;
    }

    // Director is doing this now
    public Sequence EaseOutToLeft()
    {
        var duration = 0.3f;

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveX(-1000, duration).SetEase(Ease.InSine));
        return seq;
    }

}
