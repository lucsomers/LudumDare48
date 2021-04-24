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
    private const KeyCode interactButtonKey = KeyCode.E;

    private bool moveUp = false;
    private bool moveDown = false;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool interactButton = false;

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(MoveUpKey);
        moveDown = Input.GetKey(MoveDownKey);
        moveRight = Input.GetKey(MoveRightKey);
        moveLeft = Input.GetKey(MoveLeftKey);

        interactButton = Input.GetKeyDown(interactButtonKey);
    }

    public bool MoveUp { get => moveUp; }
    public bool MoveDown { get => moveDown; }
    public bool MoveLeft { get => moveLeft; }
    public bool MoveRight { get => moveRight; }
    public bool InteractButton { get => interactButton;}
}
