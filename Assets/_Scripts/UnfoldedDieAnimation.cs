using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UnfoldedDieAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;
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

        GameManager.Instance.PuzzleTransitionEnd(new PlayerActionEventArgs());

    }

    public void PlaySuccessAnimation(OnSubmitEventArgs args)
    {
        _animator.SetBool("Pass", true);
    }

    public void PlaySkipAnimation(OnSkipEventArgs args)
    {
        _animator.SetTrigger("Skip");
    }

    public void ExitAnimationComplete()
    {
        OnExitAnimationComplete?.Invoke();
    }

}
