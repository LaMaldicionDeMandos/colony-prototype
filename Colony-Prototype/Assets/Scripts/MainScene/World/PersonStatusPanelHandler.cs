using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStatusPanelHandler : MonoBehaviour, ClickableHandler {
    public string type;

    void Start() {
        ItemSelectionManager.instance.Subscribe(type, this);
        Enable(false);
    }

    void Update() {}

    public void OnSelect(GameObject gameObject) {
        Debug.Log("Person " + gameObject.name + " Selected");
       Enable(true);
    }

    public void OnUnselect(GameObject gameObject) {
        Debug.Log("Person " + gameObject.name + " Selected");
        Enable(false);
    }

    private void Enable(bool enable) {
        transform.localScale = enable ? Vector3.one : Vector3.zero;
    }
}
