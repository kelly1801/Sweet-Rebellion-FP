using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Scriptables/Players")]
public class Player : ScriptableObject
{
    public GameObject prefab;
    public Sprite sprite;
    public new string name;
}