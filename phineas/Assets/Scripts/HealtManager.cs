using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealtManager : MonoBehaviour
{
    public static HealtManager instance;

    public Image playerHealtBar;
    public Image enemyHealtBar;

    public TextMeshProUGUI playerHpText;
    public TextMeshProUGUI enemyHpText;

    public float playerHealt = 10f;
    private float maxHealt;
    
    public bool EnemyDeath = false;
    private bool PlayerDeath = false;

    private void Awake()
    {
        instance = this;
        maxHealt = playerHealt;
        playerHpText.text = playerHealt.ToString();
    }

    public void PlayerTakeDamage(float damage)
    {
        playerHealt -= damage;
        playerHealtBar.fillAmount = playerHealt / maxHealt;
        playerHpText.text = playerHealt.ToString();
    }

    public float EnemyTakeDamge(float damage, float enemyHealt, float maxhealt)
    {
        enemyHealt -= damage;
        enemyHealtBar.fillAmount = enemyHealt / maxhealt;
        enemyHpText.text = enemyHealt.ToString();
        return enemyHealt; 
    }

    public void FixedUpdate() 
    {
        if (Enemy.Instance.enemyObject.healt == 0 && EnemyDeath == false)
        {
            EnemyDeath = true;
            Debug.Log("Enemy is verslagen");
        }

        if (playerHealt == 0f && PlayerDeath == false)
        {
            PlayerDeath = true;
            Debug.Log("Player is verslagen");
        }
    }

}
