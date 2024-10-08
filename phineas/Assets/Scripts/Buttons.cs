using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public static Buttons Instance;
    public Button[] ArchitectuurButtons;
    public Button[] ActiviteitButtons;
    public int ClickIndex = 0;
    public int ArchitectuurIndex;
    public int ActiviteitIndex;
    
    private void Awake()
    {
        Instance = this;
    }

    public void Achtitectuurlaag_Button(Button clickedButton)
    {
        foreach (Button button in ArchitectuurButtons)
        {
            if (button == clickedButton)
            {
                ClickIndex++;
                clickedButton.GetComponent<Image>().color = Color.red;
                clickedButton.enabled = false;
                Enemy.Instance.archiButton = clickedButton;
                continue;
            }
            button.interactable = false;
        }
    }

    public void Activiteit_Button(Button clickedButton)
    {
        foreach (Button button in ActiviteitButtons)
        {
            if (button == clickedButton)
            {
                ClickIndex++;
                clickedButton.GetComponent<Image>().color = Color.red;
                clickedButton.enabled = false;
                Enemy.Instance.actiButton = clickedButton; 
                continue;
            }
            button.interactable = false;
        }
    }

    public void ActiIndexButton(int index)
    {
        ActiviteitIndex = index;
    }

    public void ArchIndexButton(int index)
    {
        ArchitectuurIndex = index;
    }

    public void FixedUpdate()
    {
        if(ClickIndex == 2 && HealtManager.instance.EnemyDeath == false)
        {
            Enemy.Instance.EnemyTurn(ArchitectuurIndex, ActiviteitIndex);
        }
    }
}
