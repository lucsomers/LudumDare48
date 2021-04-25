using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator shopAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopAnimator.SetBool("ShowButton", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopAnimator.SetBool("ShowButton", false);
        }
    }
}
