using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShop : Shop
{
    [SerializeField] private int healAmount;

    private void Update()
    {
        if (canBuy)
        {
            if (InputReader.instance.InteractButton)
            {
                if (PlayerInventory.instance.PayMoney(upgradeCost))
                {
                    PlayerHealth.instance.HealPlayer(healAmount);
                    buyParticles.Play();
                    AudioManager.instance.PlaySound(AudioType.BUY, true);
                }
            }
        }
    }
}
