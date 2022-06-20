using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScripts : MonoBehaviour
{
    public float minY = -4.3f, maxY = 4.3f;

    public GameObject[] asteroidPrefabs;
    public GameObject enemyPrefab;

    public float timer = 2f;
    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    void Update()
    {

    }

    void SpawnEnemies()
    {
        float posY = Random.Range(minY, maxY);
        Vector3 temp = transform.position;
        temp.y = posY;
        if (Random.Range(0, 2) > 0)
        {
            Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)],temp,Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 90f));
        }
        Invoke("SpawnEnemies", timer);
    }
}
