using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Set", menuName = "Scriptables/PlayerSet")]
public class PlayerSet : ScriptableObject
{
    public Player[] players;

    public int Length {
        get => players.Length;
    }
}