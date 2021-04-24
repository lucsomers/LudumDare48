using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region SingleTon

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] private int maxHealth = 3;

    private int currentHealth = 0;

    public void HealPlayer(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateGraphic();
    }

    public void DamagePlayer(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateGraphic();
    }

    private void UpdateGraphic()
    {

    }

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
}
