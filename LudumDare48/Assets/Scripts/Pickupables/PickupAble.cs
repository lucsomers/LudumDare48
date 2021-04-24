using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : MonoBehaviour
{
    [SerializeField] private bool destroyOnCollision;

    [SerializeField] private GameObject particles;

    private const float timeBeforeDestroy = 0.1f;

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

        CreateParticles();

        StartCoroutine(DestroySelf());
    }

    private void CreateParticles()
    {
        GameObject go = Instantiate(particles);
        go.transform.position = transform.position;
        go.SetActive(true);
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        if (destroyOnCollision)
        {
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
