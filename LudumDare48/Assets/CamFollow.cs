using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private const float minXPos = 0;
    private const float maxXPos = 9.22f;

    private const float yOffset = -1.89f;

    [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    void LateUpdate()
    {
        float calculatedY = playerTransform.position.y + yOffset;

        if (playerTransform.position.x <= minXPos)
        {
            transform.position = new Vector3(minXPos, calculatedY, transform.position.z);
        }
        else if (playerTransform.position.x >= maxXPos)
        {
            transform.position = new Vector3(maxXPos, calculatedY, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(playerTransform.position.x, calculatedY, transform.position.z);
        }
    }
}
