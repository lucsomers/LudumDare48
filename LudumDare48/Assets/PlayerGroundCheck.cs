using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    private bool isGrounded = true;
    private bool bottomLine = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.transform.CompareTag("BottomLine"))
        {
            bottomLine = true;
        }

        if (collision.transform.CompareTag("Rock"))
        {
            collision.GetComponent<RockManager>().HandleRockHit();
            bottomLine = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (collision.transform.CompareTag("BottomLine"))
        {
            bottomLine = false;
        }

        if (collision.transform.CompareTag("Rock"))
        {
            bottomLine = false;
        }
    }

    public bool IsGrounded { get => isGrounded; }
    public bool BottomLine { get => bottomLine; set => bottomLine = value; }
}
