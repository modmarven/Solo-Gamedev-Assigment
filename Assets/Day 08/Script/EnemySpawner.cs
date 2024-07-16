using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject emptyGameObject;
    public float spawnRate = 2.0f;
    public float spawnDistance = 10.0f;

    private float nextSpawnTime = 0f;

    
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnRate;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        GameObject clone = Instantiate(enemyPrefabs, spawnPosition, Quaternion.identity);
        clone.transform.SetParent(emptyGameObject.transform);

    }

    private Vector3 GetRandomSpawnPosition()
    {
        Camera mainCamera = Camera.main;
        Vector2 cameraPosition = mainCamera.transform.position;
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = mainCamera.aspect * cameraHeight;

        int side = Random.Range(0, 4);
        Vector2 spawnPosition = Vector2.zero;

        switch (side)
        {
            case 0: // Top
                spawnPosition = new Vector3(Random.Range(cameraPosition.x - cameraWidth, cameraPosition.x + cameraWidth), cameraPosition.y + cameraHeight + spawnDistance, 0);
                break;
            case 1: // Bottom
                spawnPosition = new Vector3(Random.Range(cameraPosition.x - cameraWidth, cameraPosition.x + cameraWidth), cameraPosition.y - cameraHeight - spawnDistance, 0);
                break;
            case 2: // Left
                spawnPosition = new Vector3(cameraPosition.x - cameraWidth - spawnDistance, Random.Range(cameraPosition.y - cameraHeight, cameraPosition.y + cameraHeight), 0);
                break;
            case 3: // Right
                spawnPosition = new Vector3(cameraPosition.x + cameraWidth + spawnDistance, Random.Range(cameraPosition.y - cameraHeight, cameraPosition.y + cameraHeight), 0);
                break;
        }

        return spawnPosition;
    }
}
