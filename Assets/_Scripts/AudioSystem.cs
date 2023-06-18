using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;



public class AudioSystem : Singleton<AudioSystem>
{


    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _sfxSource;



    [SerializeField] AudioClip buzzerClip;
    [SerializeField] AudioClip flameClip;
    [SerializeField] AudioClip bellClip;



    // Update is called once per frame

    private void OnEnable()
    {
        PlayerActions.OnSubmit += PlayBellSound;
        PlayerActions.OnSkip += PlayBuzzerSound;
    }

    private void OnDisable()
    {
        PlayerActions.OnSubmit -= PlayBellSound;
        PlayerActions.OnSkip -= PlayBuzzerSound;
    }

    public void PlaySound(AudioClip clip, float volumeScale)
    {
        _sfxSource.PlayOneShot(clip, volumeScale);
    }

    public void PlayBuzzerSound(FinishTurnEventArgs args)
    {
        PlaySound(buzzerClip, 1f);
    }

    public void PlayBellSound(FinishTurnEventArgs args)
    {
        PlaySound(bellClip, 1f);
    }

    public void PlayFlameSound()
    {
        PlaySound(flameClip, 1f);
    }




}
