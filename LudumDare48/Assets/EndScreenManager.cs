using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    public void OnBtnQuit_Click()
    {
        ScreenManager.instance.Quit();
    }

    public void OnBtnReturnToMenu_Click()
    {
        ScreenManager.instance.GoToMenu();
    }
}
