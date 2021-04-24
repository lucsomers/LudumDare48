using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : MonoBehaviour
{
    [SerializeField] private bool destroyOnCollision;

    public virtual void HandlePickup(PlayerInventory playerInventory)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            HandlePickup(playerInventory);
        }

        if (destroyOnCollision)
        {
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
