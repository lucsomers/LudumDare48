using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    #region SingleTon

    public static ParticleManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] private GameObject undergroundDownwardParticleSystem;
    [SerializeField] private GameObject undergroundUpwardParticleSystem;
    [SerializeField] private TrailRenderer trail;

    public void SetUpwardParticleSystem(bool active)
    {
        undergroundUpwardParticleSystem.SetActive(active);
    }

    public void SetDownwardParticleSystem(bool active)
    {
        undergroundDownwardParticleSystem.SetActive(active);
    }

    public void SetDiggingTrail(bool active)
    {
        trail.emitting = active;
    }
}
