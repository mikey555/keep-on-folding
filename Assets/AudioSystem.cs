using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;



public class AudioSystem : MonoBehaviour
{
    private static AudioSystem _instance;
    public static AudioSystem Instance { get => _instance; set => _instance = value; }

    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _sfxSource;



    [SerializeField] AudioClip buzzerClip;
    [SerializeField] AudioClip flameClip;
    [SerializeField] AudioClip bellClip;


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
    // Update is called once per frame

    public void PlaySound(AudioClip clip, float volumeScale)
    {
        _sfxSource.PlayOneShot(clip, volumeScale);
    }

    public void PlayBuzzerSound()
    {
        PlaySound(buzzerClip, 1f);
    }

    public void PlayBellSound()
    {
        PlaySound(bellClip, 1f);
    }

    public void PlayFlameSound()
    {
        PlaySound(flameClip, 1f);
    }




}
