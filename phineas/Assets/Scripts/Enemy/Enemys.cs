using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "New Enemy", menuName ="Scriptable Objects")]
public class Enemys : ScriptableObject
{
    public new string name;
    public string description;

    public float healt = 2;

    public Sprite enemySprite;

    public int achritectuurlaagIndex;
    public int activiteitIndex;
}
