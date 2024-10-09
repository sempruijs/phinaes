using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn instance;
    public Enemys[] Enemys;
    public Enemys enemy;

    void Awake()
    {
        EnemySpawn instance = this;
        enemy = Enemys[Random.Range(0, Enemys.Length)];
    }

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = enemy.enemySprite;
    }
}
