using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuListerner : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;

    // Update is called once per frame
    void Update()
    {
        if (InputReader.instance.OpenMenu)
        {
            if (!menuScreen.activeSelf)
            {
                menuScreen.SetActive(true);
                InputReader.instance.PauseGame(true);
            }
            else
            {
                menuScreen.SetActive(false);
                InputReader.instance.PauseGame(false);
            }
            
        }
    }
}
