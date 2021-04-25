using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioType audioType;

    private AudioSource source;
    
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySoundOnLoop()
    {
        source = GetComponent<AudioSource>();
        source.loop = true;
        source.Play();
    }

    public void PlaySound()
    {
        source = GetComponent<AudioSource>();
        source.loop = false;
        source.Play();
    }

    public void StopSound()
    {
        source = GetComponent<AudioSource>();
        source.loop = false;
        source.Stop();
    }

    public AudioType AudioType { get => audioType; set => audioType = value; }

}
