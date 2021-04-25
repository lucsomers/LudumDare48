using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioType audioType;

    private AudioSource source;
    
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySoundOnLoop()
    {
        source.loop = true;
        source.Play();
    }

    public void PlaySound()
    {
        source.loop = false;
        source.Play();
    }

    public void StopSound()
    {
        source.loop = false;
        source.Stop();
    }

    public AudioType AudioType { get => audioType; set => audioType = value; }

}
