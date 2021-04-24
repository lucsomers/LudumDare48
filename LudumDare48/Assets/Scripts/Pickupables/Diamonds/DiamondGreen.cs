using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DiamondGreen : PickupAble
{
    private const int diamonValue = 3;

    public override void HandlePickup(PlayerInventory playerInventory)
    {
        base.HandlePickup(playerInventory);

        playerInventory.GiveMoney(diamonValue);
    }
}
