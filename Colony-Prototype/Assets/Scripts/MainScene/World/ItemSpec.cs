using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSpec {
    public string name;
    public ElementSpawnSpec spawnSpec;

    public HarvestSpec harvest;
}
