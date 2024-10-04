using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button[] ArchitectuurButtons;
    public Button[] ActiviteitButtons;
    public int ClickIndex = 0;
    public int ArchitectuurIndex;
    public int ActiviteitIndex;
    public void Achtitectuurlaag_Button(Button clickedButton)
    {
        foreach (Button button in ArchitectuurButtons)
        {
            if (button == clickedButton)
            {
                ClickIndex++;
                clickedButton.GetComponent<Image>().color = Color.red;
                clickedButton.enabled = false;
                ArchitectuurIndex = Array.FindIndex(ArchitectuurButtons, button => button == clickedButton);
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
                ActiviteitIndex = Array.FindIndex(ArchitectuurButtons, button => button == clickedButton);
                continue;
            }
            button.interactable = false;
        }
    }

    public IEnumerator ButtonsReset()
    {
        ClickIndex = 0;
        yield return new WaitForSeconds(2);

        foreach (Button button in ArchitectuurButtons)
        {
            button.GetComponent<Image>().color = Color.white;
            button.enabled = true;
            button.interactable = true;
        }

        foreach (Button button in ActiviteitButtons)
        {
            button.GetComponent<Image>().color = Color.white;
            button.enabled = true;
            button.interactable = true;
        }

        Enemy.Instance.EnemyTurn(ArchitectuurIndex, ActiviteitIndex);
    }

    public void FixedUpdate()
    {
        if(ClickIndex == 2)
        {
            StartCoroutine(ButtonsReset());
        }
    }
}
