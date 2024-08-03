using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Persistable {
    string Serialize();
    string ComponentClassName();
}
