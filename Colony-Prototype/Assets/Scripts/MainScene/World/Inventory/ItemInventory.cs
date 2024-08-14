using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ItemInventory {
    public ItemInventorySpec itemSpec;
    public int amount;

    public ItemInventory(ItemInventorySpec itemSpec, int amount) {
        this.itemSpec = itemSpec;
        this.amount = amount;
    }

    public string name => itemSpec.name;
    public string icon => itemSpec.icon;
}
