using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpec {
    public string name;
    public string icon;

    public ItemSpec(string name) {
        this.name = name;
    }
    public ItemSpec(string name, string icon) {
        this.name = name;
        this.icon = icon;
    }
}
