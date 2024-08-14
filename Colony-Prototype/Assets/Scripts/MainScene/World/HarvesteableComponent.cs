using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesteableComponent : MonoBehaviour, Harvesteable {
    public ItemSpec itemSpec;
    void Start() {}

    void Update() {}

    public void Harvest() {
        Debug.Log("Harvest " + itemSpec.name);
    }
}
