using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawner : MonoBehaviour
{
    public GameObject[] dinoPrefabs;
    public Vector3 spawnArea;
    public int spawnCount = 3;

    void Start()
    {
        SpawnDinos();
    }

    void SpawnDinos()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float randomX = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
            float randomY = Random.Range(-spawnArea.y / 2, spawnArea.y / 2);
            float randomZ = Random.Range(-spawnArea.z / 2, spawnArea.z / 2);

            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ) + transform.position;

            int randomIndex = Random.Range(0, dinoPrefabs.Length);
            GameObject randomDino = dinoPrefabs[randomIndex];

            Instantiate(randomDino, spawnPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
}