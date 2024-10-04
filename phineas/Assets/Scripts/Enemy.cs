using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    public Enemys enemyObject;
    public Image enemySprite;
    private float maxhealt;

    public void Awake()
    {
        // Krijg enemy waarmee je in gevecht raakte
        Instance = this;
        enemySprite.sprite = enemyObject.enemySprite;
        maxhealt = enemyObject.healt;
    }

    public void EnemyTurn(int AchritectuurlaagIndex, int ActiviteitIndex)
    {
        float playerDamage = 0;
        float enemyDamage = 0;
        if (enemyObject.achritectuurlaagIndex == AchritectuurlaagIndex)
        {
            enemyDamage++;
        }
        else
        {
            playerDamage++;
        }

        if (enemyObject.activiteitIndex == ActiviteitIndex) 
        {
            enemyDamage++;
        }
        else
        {
            playerDamage++;
        }

        enemyObject.healt = HealtManager.instance.EnemyTakeDamge(enemyDamage, enemyObject.healt, maxhealt);
        HealtManager.instance.PlayerTakeDamage(playerDamage);
    }
}
