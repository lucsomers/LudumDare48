using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialScreen;

    private void Start()
    {
        AudioManager.instance.PlaySound(AudioType.MENU, true);
    }

    public void  BtnStartGame_Click()
    {
        ScreenManager.instance.GoToGame();
    }

    public void BtnQuitGame_Click()
    {
        ScreenManager.instance.Quit();
    }
    public void BtnTutorial_Click()
    {
        tutorialScreen.SetActive(true);
    }

    public void BtnReturnToMenu_Click()
    {
        tutorialScreen.SetActive(false);
    }
}
