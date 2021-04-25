using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    private const int maxRockHealth = 4;

    private int currentHealth;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxRockHealth;
    }

    public void HandleRockHit()
    {
        currentHealth--;
        animator.SetInteger("RockHealth", currentHealth);
        StartCoroutine( CheckDeath());
    }

    IEnumerator CheckDeath()
    {
        yield return new WaitForSeconds(0.1f);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
