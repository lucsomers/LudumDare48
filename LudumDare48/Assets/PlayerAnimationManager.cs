using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    #region SingleTon
    public static PlayerAnimationManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
    }
    #endregion

    private SpriteRenderer renderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Drill(bool upward)
    {
        if (upward)
        {
            renderer.flipY = true;
        }
        else
        {
            renderer.flipY = false;
        }

        animator.SetBool("Drilling", true);
    }

    public void Move(bool moveRight)
    {
        if (moveRight)
        {
            renderer.flipX = false;
            renderer.flipY = false;
        }
        else
        {
            renderer.flipX = true;
            renderer.flipY = false;
        }

        animator.SetBool("Move", true);
        animator.SetBool("Drilling", false);
    }

    public void Idle()
    {
        animator.SetBool("Drilling", false);
        animator.SetBool("Move", false);
    }
}
