using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemys[] enemys;
    public GameObject[] spawnPoints;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);

    }
}
