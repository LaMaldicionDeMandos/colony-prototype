using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ClickableHandler : IEventSystemHandler {
    void OnSelect(GameObject gameObject);
    void OnUnselect(GameObject gameObject);
}
