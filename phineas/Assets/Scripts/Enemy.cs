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
    private bool archiAanval = false;
    private bool actiAanval = false;

    public Button archiButton;
    public Button actiButton;

    public void Awake()
    {
        // Krijg enemy waarmee je in gevecht raakte
        Instance = this;
        enemySprite.sprite = enemyObject.enemySprite;
        enemyObject.healt = 2f;
        maxhealt = enemyObject.healt;
    }

    public void EnemyTurn(int AchritectuurlaagIndex, int ActiviteitIndex)
    {
        float playerDamage = 0;
        float enemyDamage = 0;
        if(archiAanval == false)
        {
            if (enemyObject.achritectuurlaagIndex == AchritectuurlaagIndex)
            {
                enemyDamage++;
                archiAanval = true;
                archiButton.GetComponent<Image>().color = Color.green;
            }
            else
            {
                playerDamage++;
                StartCoroutine(ArchiButtonsReset());
            }
        }

        if (actiAanval == false) 
        {
            if (enemyObject.activiteitIndex == ActiviteitIndex)
            {
                actiAanval = true;
                enemyDamage++;
                actiButton.GetComponent<Image>().color = Color.green;
            }
            else
            {
                playerDamage++;
                StartCoroutine(ActiButtonsReset());
            }
        }

        Debug.Log("Player Damage: " + playerDamage + " - " + "enemy Damage: " + enemyDamage);
        enemyObject.healt = HealtManager.instance.EnemyTakeDamge(enemyDamage, enemyObject.healt, maxhealt);
        HealtManager.instance.PlayerTakeDamage(playerDamage);
    }

    public IEnumerator ArchiButtonsReset()
    {
        Buttons.Instance.ClickIndex--;
        yield return new WaitForSeconds(1);

        foreach (Button button in Buttons.Instance.ArchitectuurButtons)
        {
            button.GetComponent<Image>().color = Color.white;
            button.enabled = true;
            button.interactable = true;
        }
    }

    public IEnumerator ActiButtonsReset()
    {
        Buttons.Instance.ClickIndex--;
        yield return new WaitForSeconds(1);

        foreach (Button button in Buttons.Instance.ActiviteitButtons)
        {
            button.GetComponent<Image>().color = Color.white;
            button.enabled = true;
            button.interactable = true;
        }
    }
}
