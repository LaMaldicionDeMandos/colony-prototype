using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HarvestSpec {
    public HarvestCondition condition;
    public string dificulty;

    public List<ItemInventory> collect;

    public string onHarvest;

    public string harvestType;

}
