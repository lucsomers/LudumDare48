using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : PickupAble
{
    [SerializeField] private int diamondValue = 1;

    public override void HandlePickup(PlayerInventory playerInventory)
    {
        playerInventory.GiveMoney(diamondValue);
        PlayerStats.instance.UpDiamondsTotal(diamondValue);
    }
}
