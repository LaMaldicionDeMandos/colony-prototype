using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInventorySpec {
    public string name;
    public string icon;

    public string onDropItemName;
    public int onDropInventoryAmount; 

    public ItemInventorySpec(string name) {
        this.name = name;
    }
    public ItemInventorySpec(string name, string icon) {
        this.name = name;
        this.icon = icon;
    }
}
