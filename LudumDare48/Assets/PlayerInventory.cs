using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region SingleTon

    public static PlayerInventory instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    private int currentAmountOfDiamonds = 0;

    private void Start()
    {
            PlayerUIManager.instance.UpdateDiamondText(currentAmountOfDiamonds.ToString());
    }

    public bool PayMoney(int coinValue)
    {
        if (coinValue <= currentAmountOfDiamonds)
        {
            currentAmountOfDiamonds -= coinValue;
            PlayerUIManager.instance.UpdateDiamondText(currentAmountOfDiamonds.ToString());
            return true;
        }

        return false;
    }

    public void GiveMoney(int coinValue)
    {
            currentAmountOfDiamonds += coinValue;
            PlayerUIManager.instance.UpdateDiamondText(currentAmountOfDiamonds.ToString());
    }

    public int CurrentAmountOfMoney { get => currentAmountOfDiamonds; set => currentAmountOfDiamonds = value; }
}
