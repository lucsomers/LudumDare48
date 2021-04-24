using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BouncePowerShop : Shop
{
    [SerializeField] private float modifierToSell;

    private void Update()
    {
        if (canBuy)
        {
            if (InputReader.instance.InteractButton)
            {
                if (PlayerInventory.instance.PayMoney(upgradeCost))
                {
                    PlayerStats.instance.AddDigUpForceModifier(modifierToSell);
                    PlayerUIManager.instance.UpdateJumpPowerText(PlayerStats.instance.DigUpForceReadable());
                }
            }
        }
    }
}