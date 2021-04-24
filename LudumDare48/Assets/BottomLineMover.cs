using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLineMover : MonoBehaviour
{
    #region SingleTon

    public static BottomLineMover instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] private float stepSize;
    [SerializeField] private float moveDownSpeed;

    private float currentMoveDownSpeed;

    private void Start()
    {
        currentMoveDownSpeed = moveDownSpeed;
    }

    public void MoveLineDown()
    {
        transform.position -= new Vector3(0, stepSize, 0);
    }

    private void Update()
    {
        transform.position -= new Vector3(0, currentMoveDownSpeed * Time.deltaTime, 0);
    }
}
