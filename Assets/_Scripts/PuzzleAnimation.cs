using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PuzzleAnimation : MonoBehaviour
{
    Animator _animator;
    public static event Action OnExitAnimationComplete;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        PlayerActions.OnSubmit += PlaySuccessAnimation;
        PlayerActions.OnSkip += PlaySkipAnimation;
    }

    private void OnDisable()
    {
        PlayerActions.OnSubmit -= PlaySuccessAnimation;
        PlayerActions.OnSkip -= PlaySkipAnimation;
    }

    // Animation callback
    public void PuzzleTransitionEnd()
    {

        GameManager.Instance.PuzzleTransitionEnd();

    }

    public void PlaySuccessAnimation()
    {
        _animator.SetBool("Pass", true);
    }

    public void PlaySkipAnimation()
    {
        _animator.SetTrigger("Skip");
    }

    public void ExitAnimationComplete()
    {
        OnExitAnimationComplete?.Invoke();
    }

}
