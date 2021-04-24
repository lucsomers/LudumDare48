using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [Header("Digging")]
    [SerializeField] private float digUpForce;

    private bool isDigging = false;

    private float currentDigTimer = 0;

    private Rigidbody2D rb;
    private PlayerGroundCheck groundCheck;
    private Collider2D circleCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        groundCheck = GetComponentInChildren<PlayerGroundCheck>();
    }

    private void FixedUpdate()
    {        
        if (InputReader.instance.MoveDown)
        {
            HandleStep(MoveDirection.DOWN);
        }

        if (InputReader.instance.MoveLeft)
        {
            HandleStep(MoveDirection.LEFT);
        }

        if (InputReader.instance.MoveRight)
        {
            HandleStep(MoveDirection.RIGHT);
        }

        if (groundCheck.BottomLine)
        {
            rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(new Vector2(0, digUpForce),ForceMode2D.Impulse);
        }

        if (isDigging)
        {
            if (!groundCheck.IsGrounded)
            {
                circleCollider.enabled = true;
                isDigging = false;
            }
        }
    }

    private void HandleStep(MoveDirection directionToMoveIn)
    {
        switch (directionToMoveIn)
        {
            case MoveDirection.DOWN:
                if (groundCheck.IsGrounded && !isDigging)
                {
                    isDigging = true;
                    circleCollider.enabled = false;
                }
                break;
            case MoveDirection.LEFT:
                if (rb.velocity.x > -maxSpeed)
                {
                    rb.AddForce(new Vector2(-speed, 0));
                }
                break;
            case MoveDirection.RIGHT:
                if (rb.velocity.x < maxSpeed)
                {
                    rb.AddForce(new Vector2(speed, 0));
                }
                break;
            default:
                break;
        }
    }
}
