using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create Item")]
public class SOItem : ScriptableObject
{
    public GameObject itemPrefab;

    public string itemName;
    public string itemDescription;
}
