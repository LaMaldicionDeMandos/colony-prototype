using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapItemSpec {
    public string itemName; 

    [SerializeField]
    public ItemSpawnCondition[] spawnConditions;
}
