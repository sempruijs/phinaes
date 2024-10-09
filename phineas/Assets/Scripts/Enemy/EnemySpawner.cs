using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] spawnPoints;
    public float waitTime;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
        Vector3 spawnPointCoords = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        Instantiate(prefab, spawnPointCoords, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(SpawnEnemy());
    }
}
