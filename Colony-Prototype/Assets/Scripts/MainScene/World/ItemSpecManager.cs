using System.Collections;
using System.Collections.Generic;


public class ItemSpecManager {
    public List<ItemSpec> Items;

    public ItemSpecManager(List<ItemSpec> items) {
        Items = items;
    }

    public ItemSpecManager() {
        Items = new List<ItemSpec> { new ItemSpec("Stone") };
    }

}
