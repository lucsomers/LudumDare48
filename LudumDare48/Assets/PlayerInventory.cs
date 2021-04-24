using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int currentAmountOfMoney = 0;
    
    public void GiveMoney(int coinValue)
    {
        if (coinValue > 0)
        {
            currentAmountOfMoney += coinValue;
            Debug.Log("Current amount of money = " + currentAmountOfMoney);
        }
    }

    public int CurrentAmountOfMoney { get => currentAmountOfMoney; set => currentAmountOfMoney = value; }
}
