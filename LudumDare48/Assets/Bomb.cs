using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : PickupAble
{
    [SerializeField] private int damageAmount;


    public override void HandlePickup(PlayerInventory playerInventory)
    {
        base.HandlePickup(playerInventory);

        PlayerHealth.instance.DamagePlayer(damageAmount);
    }
}
