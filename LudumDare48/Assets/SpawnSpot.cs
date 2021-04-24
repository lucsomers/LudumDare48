using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpot : MonoBehaviour
{
    [SerializeField] private int layerNumber = 0;

    private bool hasObject = false;

    public void Spawn(GameObject toSpawn)
    {
        toSpawn.transform.position = this.transform.position;
        hasObject = true;
    }

    public int LayerNumber { get => layerNumber; }
    public bool HasObject { get => hasObject; }
}
