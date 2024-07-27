using System.Collections;
using System.Collections.Generic;

public class ItemInventory {
    public ItemSpec ItemSpec;
    public int Amount;

    public ItemInventory(ItemSpec itemSpec, int amount) {
        ItemSpec = itemSpec;
        Amount = amount;
    }
}
