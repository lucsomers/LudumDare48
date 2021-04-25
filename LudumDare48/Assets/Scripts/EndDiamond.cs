using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EndDiamond : PickupAble
{
    [SerializeField] private int diamondValue = 100;

    public override void HandlePickup(PlayerInventory playerInventory)
    {
        playerInventory.GiveMoney(diamondValue);
        PlayerStats.instance.UpDiamondsTotal(diamondValue);
        StartCoroutine(EndGame());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            HandlePickup(playerInventory);
        }

        CreateParticles();

    }

    private IEnumerator EndGame()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(1);
        ScreenManager.instance.EndGame();
    }
}
