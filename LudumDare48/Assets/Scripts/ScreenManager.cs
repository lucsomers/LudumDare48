using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    #region SingleTon
    public static ScreenManager instance;

    private void Awake()
    {
        if(instance == null || instance != this)
        {
            Destroy(instance);
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    private const int MenuIndex = 0;
    private const int GameIndex = 1;
    private const int EndScreenIndex = 2;

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToGame()
    {
        AudioManager.instance.PlaySound(AudioType.MENU, false);
        SceneManager.LoadScene(GameIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(MenuIndex);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(EndScreenIndex);
    }
}