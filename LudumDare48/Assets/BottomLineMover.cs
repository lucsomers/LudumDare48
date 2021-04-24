using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLineMover : MonoBehaviour
{
    [SerializeField] private float lineSpeed;
    [SerializeField] private float stepSize;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            transform.position -= new Vector3(0, stepSize * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position -= new Vector3(0, stepSize * Time.deltaTime, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, lineSpeed * Time.deltaTime, 0);
    }
}
