using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 20f;
    public float spawnPosZ = 20f;
    public float startDelay = 2f;
    public float spawnInterval = 1.5f;
    public float sideSpawnZMin = -20f;
    public float sideSpawnZMax = 20f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval * 2);
        InvokeRepeating("SpawnRightAnimal", startDelay + spawnInterval, spawnInterval * 2);
    }

    private void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
       Instantiate(animalPrefabs[animalIndex],spawnPos,animalPrefabs[animalIndex].transform.rotation);
    }

    private void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-spawnRangeX, 0, Random.Range(sideSpawnZMin, sideSpawnZMax));
        Quaternion rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
        Instantiate(animalPrefabs[animalIndex], spawnPos, rotation);
    }

    private void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnRangeX, 0, Random.Range(sideSpawnZMin, sideSpawnZMax));
        Quaternion rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
        Instantiate(animalPrefabs[animalIndex], spawnPos, rotation);
    }
}