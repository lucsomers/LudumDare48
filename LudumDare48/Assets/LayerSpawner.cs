using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSpawner : MonoBehaviour
{
    private const int MaxAmountOfTries = 10;

    [Header("BadStuff")]
    [SerializeField] private GameObject bomb;

    [Header("Diamond prefabs")]
    [SerializeField] private GameObject blueCrystal;
    [SerializeField] private GameObject greenCrystal;
    [SerializeField] private GameObject redCrystal;
    
    [Header("Amount of crystals")]
    [SerializeField] private int amountOfBlueCrystals;
    [SerializeField] private int amountOfGreenCrystals;
    [SerializeField] private int amountOfRedCrystals;
    [SerializeField] private int amountOfBombs;

    private int currentAmountOfBlueCrystals = 0;
    private int currentAmountOfGreenCrystals = 0;
    private int currentAmountOfRedCrystals = 0;
    private int currentAmountOfBombs = 0;

    private List<SpawnSpot> spawnSpotsInLayer = new List<SpawnSpot>();

    void Start()
    {
        FillListWithAllSpawnSpotsInLayer();

        SpawnCrystals();
    }

    private void SpawnCrystals()
    {
        int currentAmountOfSpawnedCrystals = 0;
        int totalAmountOfCrystals = amountOfBlueCrystals + amountOfGreenCrystals + amountOfRedCrystals;

        while (currentAmountOfSpawnedCrystals < totalAmountOfCrystals)
        {
            GameObject toSpawn = null;
         
            if (currentAmountOfBombs < amountOfBombs)
            {
                toSpawn = Instantiate(bomb);
                currentAmountOfBombs++;
            }
            else if (currentAmountOfBlueCrystals < amountOfBlueCrystals)
            {
                toSpawn = Instantiate(blueCrystal);
                currentAmountOfBlueCrystals++;
            }
            else if (currentAmountOfGreenCrystals < amountOfGreenCrystals)
            {
                toSpawn = Instantiate(greenCrystal);
                currentAmountOfGreenCrystals++;
            }
            else if (currentAmountOfRedCrystals < amountOfRedCrystals)
            {
                toSpawn = Instantiate(redCrystal);
                currentAmountOfRedCrystals++;
            }

            if (toSpawn != null)
            {
                GetRandomSpawnSpot().Spawn(toSpawn);
                currentAmountOfSpawnedCrystals++;
            }
        }
    }

    private SpawnSpot GetRandomSpawnSpot()
    {
        for (int i = 0; i < MaxAmountOfTries; i++)
        {
            SpawnSpot spawnSpotToReturn = spawnSpotsInLayer[Random.Range(0, spawnSpotsInLayer.Count)];

            if (!spawnSpotToReturn.HasObject)
            {
                return spawnSpotToReturn;
            }
        }

        return spawnSpotsInLayer[0];
    }

    private void FillListWithAllSpawnSpotsInLayer()
    {
        foreach (SpawnSpot spawnspot in GetComponentsInChildren<SpawnSpot>())
        {
            spawnSpotsInLayer.Add(spawnspot);
        }
    }
}
