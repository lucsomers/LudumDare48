using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region SingleTon
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    private List<AudioPlayer> audioPlayers = new List<AudioPlayer>();

    private void Start()
    {
        foreach (AudioPlayer audioPlayer in GetComponentsInChildren<AudioPlayer>())
        {
            audioPlayers.Add(audioPlayer);
        }
    }

    public void PlaySound(AudioType audioType, bool turnOn)
    {
        switch (audioType)
        {
            case AudioType.MOVE:
                PlayMoveSound(turnOn);
                break;
            case AudioType.MENU:
                PlayMenuSound(turnOn);
                break;
            case AudioType.GAME:
                PlayGameSound(turnOn);
                break;
            case AudioType.DRILL:
                PlayDrillSound(turnOn);
                break;
            case AudioType.CRYSTAL_SMASH:
                PlayCrystalSound(turnOn);
                break;
            case AudioType.EXPLOSION:
                PlayExplosionSound(turnOn);
                break;
            case AudioType.BUY:
                PlayBuySound(turnOn);
                break;
            default:
                break;
        }
    }

    private void PlayExplosionSound(bool turnOn)
    {
        if (turnOn)
        {
            GetAudioPlayerByType(AudioType.EXPLOSION).PlaySound();
        }
        else
        {
            GetAudioPlayerByType(AudioType.EXPLOSION).StopSound();
        }
    }

    private void PlayCrystalSound(bool turnOn)
    {
        if (turnOn)
        {
            GetAudioPlayerByType(AudioType.CRYSTAL_SMASH).PlaySound();
        }
        else
        {
            GetAudioPlayerByType(AudioType.CRYSTAL_SMASH).StopSound();
        }
    }

    private void PlayDrillSound(bool turnOn)
    {
        if (turnOn)
        {
            GetAudioPlayerByType(AudioType.DRILL).PlaySound();
        }
        else
        {
            GetAudioPlayerByType(AudioType.DRILL).StopSound();
        }
    }

    private void PlayMenuSound(bool turnOn)
    {
        if (turnOn)
        {
            GetAudioPlayerByType(AudioType.MENU).PlaySoundOnLoop();
        }
        else
        {
            GetAudioPlayerByType(AudioType.MENU).StopSound();
        }
    }

    private void PlayMoveSound(bool turnOn)
    {
        if (turnOn)
        {
            GetAudioPlayerByType(AudioType.MOVE).PlaySound();
        }
        else
        {
            GetAudioPlayerByType(AudioType.MOVE).StopSound();
        }
    }

    private void PlayBuySound(bool turnOn)
    {
        if (turnOn)
        {
            GetAudioPlayerByType(AudioType.BUY).PlaySound();
        }
        else
        {
            GetAudioPlayerByType(AudioType.BUY).StopSound();
        }
    }

    private void PlayGameSound(bool turnOn)
    {
        if (turnOn)
        {
            GetAudioPlayerByType(AudioType.GAME).PlaySoundOnLoop();
        }
        else
        {
            GetAudioPlayerByType(AudioType.GAME).StopSound();
        }
    }

    private AudioPlayer GetAudioPlayerByType(AudioType type)
    {
        foreach (AudioPlayer audioPlayer in audioPlayers)
        {
            if (audioPlayer.AudioType == type)
            {
                return audioPlayer;
            }
        }

        return null;
    }
}
