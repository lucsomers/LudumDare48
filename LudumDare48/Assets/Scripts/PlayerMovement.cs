using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isDigging = false;

    private Rigidbody2D rb;
    private PlayerGroundCheck groundCheck;
    private Collider2D circleCollider;

    private int amountOfBottomLineHits = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        groundCheck = GetComponentInChildren<PlayerGroundCheck>();
        PlayerUIManager.instance.UpdateJumpPowerText(PlayerStats.instance.DigUpForceReadable());
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
            HandleBottomLineHit();
        }

        if (isDigging)
        {
            if (!groundCheck.IsGrounded)
            {
                HandleBackAboveGround();
            }
        }

        CheckForMaxSpeeds();
    }

    private void CheckForMaxSpeeds()
    {
        if (isDigging)
        {
            if (rb.velocity.y < -PlayerStats.instance.MaxVerticalSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -PlayerStats.instance.MaxVerticalSpeed);
            }

            if (rb.velocity.x > PlayerStats.instance.MaxUnderGroundSpeed)
            {
                rb.velocity = new Vector2(PlayerStats.instance.MaxUnderGroundSpeed, rb.velocity.y);
            }
            else if (rb.velocity.x < -PlayerStats.instance.MaxUnderGroundSpeed)
            {
                rb.velocity = new Vector2(-PlayerStats.instance.MaxUnderGroundSpeed, rb.velocity.y);
            }
        }
        else
        {
            if (rb.velocity.x > PlayerStats.instance.MaxAboveGroundSpeed)
            {
                rb.velocity = new Vector2(PlayerStats.instance.MaxAboveGroundSpeed, rb.velocity.y);
            }
            else if (rb.velocity.x < -PlayerStats.instance.MaxAboveGroundSpeed)
            {
                rb.velocity = new Vector2(-PlayerStats.instance.MaxAboveGroundSpeed, rb.velocity.y);
            }
        }
    }

    private void HandleBackAboveGround()
    {
        circleCollider.enabled = true;
        isDigging = false;

        ParticleManager.instance.SetUpwardParticleSystem(false);
        ParticleManager.instance.SetDownwardParticleSystem(false);
        ParticleManager.instance.SetDiggingTrail(false);

        amountOfBottomLineHits--;
    }

    private void HandleBottomLineHit()
    {
        CheckGameOver();

        BottomLineMover.instance.MoveLineDown();

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, PlayerStats.instance.DigUpForce), ForceMode2D.Impulse);

        ParticleManager.instance.SetUpwardParticleSystem(true);
        ParticleManager.instance.SetDownwardParticleSystem(false);

        amountOfBottomLineHits++;
    }

    private void CheckGameOver()
    {
        if (amountOfBottomLineHits > 1)
        {
            ScreenManager.instance.EndGame();
        }
    }

    private void HandleStep(MoveDirection directionToMoveIn)
    {
        switch (directionToMoveIn)
        {
            case MoveDirection.DOWN:
                if (groundCheck.IsGrounded && !isDigging)
                {
                    HandleGoingUnderGround();
                }
                break;

            case MoveDirection.LEFT:
                rb.AddForce(new Vector2(-PlayerStats.instance.Speed, 0));
                break;

            case MoveDirection.RIGHT:
                rb.AddForce(new Vector2(PlayerStats.instance.Speed, 0));
                break;

            default:
                break;
        }
    }

    private void HandleGoingUnderGround()
    {
        isDigging = true;
        circleCollider.enabled = false;
        ParticleManager.instance.SetUpwardParticleSystem(false);
        ParticleManager.instance.SetDownwardParticleSystem(true);
        ParticleManager.instance.SetDiggingTrail(true);
    }
}
