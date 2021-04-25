using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void  BtnStartGame_Click()
    {
        ScreenManager.instance.GoToGame();
    }

    public void BtnQuitGame_Click()
    {
        ScreenManager.instance.Quit();
    }
}
