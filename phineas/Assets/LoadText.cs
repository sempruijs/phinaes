using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadText : MonoBehaviour
{
    public TextMeshProUGUI enemyNaam;
    public TextMeshProUGUI enemyDetials;

    void Start()
    {
        enemyNaam.text = Enemy.Instance.enemyObject.name;
        enemyDetials.text = Enemy.Instance.enemyObject.description;
    }
}
