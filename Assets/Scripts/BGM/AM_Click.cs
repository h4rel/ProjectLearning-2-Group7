using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_Click : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----Audio Clip-----")]
    public AudioClip background;
    public AudioClip click;

    private void Start()
    {
        musicSource.clip = click;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
