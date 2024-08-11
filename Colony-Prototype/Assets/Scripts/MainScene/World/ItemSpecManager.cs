using System.Collections;
using System.Collections.Generic;


public class ItemSpecManager {
    public List<ItemSpec> items;

    public ItemSpecManager(List<ItemSpec> items) {
        this.items = items;
    }

    public ItemSpecManager() {
        items = new List<ItemSpec> { new ItemSpec("Stone", "stones_icon"), new ItemSpec("Fiber", "roguelikeitems.fiber_icon_2"), new ItemSpec("Stick", "roguelikeitems.stick") };
    }

}
