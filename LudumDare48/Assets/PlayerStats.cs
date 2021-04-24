using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region SingleTon

    public static PlayerStats instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] private float speed;
    [SerializeField] private float maxAboveGroundSpeed;
    [SerializeField] private float maxUnderGroundSpeed;
    [SerializeField] private float maxVerticalSpeed;
    [Header("Digging")]
    [SerializeField] private float digUpForce;

    private List<float> speedModifiers = new List<float>();
    private List<float> maxSpeedModifiers = new List<float>();
    private List<float> digUpForceModifiers = new List<float>();

    private float GetSpeed()
    {
        float modifiedSpeed = speed;

        modifiedSpeed = AddModifiers(modifiedSpeed, speedModifiers);

        return modifiedSpeed;
    }

    private float GetMaxSpeed()
    {
        float modifiedMaxSpeed = maxAboveGroundSpeed;

        modifiedMaxSpeed = AddModifiers(modifiedMaxSpeed, maxSpeedModifiers);

        return modifiedMaxSpeed;
    }

    private float GetDigUpForce()
    {
        float modifiedDigUpForce = digUpForce;
        modifiedDigUpForce = AddModifiers(modifiedDigUpForce, digUpForceModifiers);

        return modifiedDigUpForce;
    }

    private float AddModifiers(float toModify, List<float> listToLoop)
    {
        foreach (float mod in listToLoop)
        {
            toModify += mod;
        }

        return toModify;
    }

    public string DigUpForceReadable()
    {
        return digUpForceModifiers.Count.ToString();
    }

    public void AddSpeedModifier(float value) { speedModifiers.Add(value); }
    public void AddMaxSpeedModifier(float value) { maxSpeedModifiers.Add(value); }
    public void AddDigUpForceModifier(float value) { digUpForceModifiers.Add(value); }

    public float Speed { get => GetSpeed(); }
    public float MaxAboveGroundSpeed { get => GetMaxSpeed(); }
    public float DigUpForce { get => GetDigUpForce(); }
    public float MaxVerticalSpeed { get => maxVerticalSpeed; }
    public float MaxUnderGroundSpeed { get => maxUnderGroundSpeed; }
}
