using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSpec {
    public string name;
    public ElementSpawnSpec spawnSpec;

    public HarvestSpec harvest;

    public bool IsHarvesteable() {
        return harvest != null;
    }

    public string GetHarvestType() {
        return (harvest != null) ? harvest.harvestType : null;
    }
}
