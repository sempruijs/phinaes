using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealtManager : MonoBehaviour
{
    public static HealtManager instance;

    public Image playerHealtBar;
    public Image enemyHealtBar;
    public float playerHealt = 10f;
    private float maxHealt;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        maxHealt = playerHealt;
    }

    public void PlayerTakeDamage(float damage)
    {
        playerHealt -= damage;
        playerHealtBar.fillAmount = playerHealt / maxHealt;
    }

    public float EnemyTakeDamge(float damage, float enemyHealt, float maxhealt)
    {
        enemyHealt -= damage;
        enemyHealtBar.fillAmount = enemyHealt / maxhealt;
        return enemyHealt;
    }

}
