using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Kitchen Element", menuName = "KitchenObjects")]
public class KitchenObjectSO : ScriptableObject
{
    public Transform prefab;
    public Sprite elementIcon;
    public string elementName;
}
