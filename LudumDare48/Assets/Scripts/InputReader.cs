using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    #region SingelTon

    public static InputReader instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion
    
    private const KeyCode MoveUpKey = KeyCode.W;
    private const KeyCode MoveLeftKey = KeyCode.A;

  

    private const KeyCode MoveDownKey = KeyCode.S;
    private const KeyCode MoveRightKey = KeyCode.D;
    private const KeyCode MenuKey = KeyCode.Escape;
    private const KeyCode interactButtonKey = KeyCode.E;

    private bool moveUp = false;
    private bool moveDown = false;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool openMenu = false;
    private bool interactButton = false;

    private bool pauseGame = false;

    public void PauseGame(bool pauseGame)
    {
        this.pauseGame = pauseGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseGame)
        {
            moveUp = Input.GetKey(MoveUpKey);
            moveDown = Input.GetKey(MoveDownKey);
            moveRight = Input.GetKey(MoveRightKey);
            moveLeft = Input.GetKey(MoveLeftKey);

            interactButton = Input.GetKeyDown(interactButtonKey);
        }

        openMenu = Input.GetKeyDown(MenuKey);
    }

    public bool MoveUp { get => moveUp; }
    public bool MoveDown { get => moveDown; }
    public bool MoveLeft { get => moveLeft; }
    public bool MoveRight { get => moveRight; }
    public bool InteractButton { get => interactButton;}
    public bool OpenMenu { get => openMenu; }
}
