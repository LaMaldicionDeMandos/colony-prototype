using System.Collections;
using System.Collections.Generic;


public class ItemInventorySpecManager {
    public List<ItemInventorySpec> items;

    public ItemInventorySpecManager(List<ItemInventorySpec> items) {
        this.items = items;
    }

    public ItemInventorySpecManager() {
        items = new List<ItemInventorySpec> { new ItemInventorySpec("Stone", "stones_icon"), new ItemInventorySpec("Fiber", "roguelikeitems.fiber_icon_2"), new ItemInventorySpec("Stick", "roguelikeitems.stick") };
    }

}
