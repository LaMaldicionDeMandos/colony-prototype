using System.Collections;
using System.Collections.Generic;

public class ItemInventory {
    public ItemSpec itemSpec;
    public int amount;

    public ItemInventory(ItemSpec itemSpec, int amount) {
        this.itemSpec = itemSpec;
        this.amount = amount;
    }

    public string name => itemSpec.name;
    public string icon => itemSpec.icon;
}
