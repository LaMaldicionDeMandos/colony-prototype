using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalActionHandler : MonoBehaviour, ClickableHandler {

    private GameObject gameObject;
    void Start() {
        ItemSelectionManager.instance.Subscribe(this);
        Enable(false);
    }

    void Update() {}

    public void OnSelect(GameObject gameObject) {
        Debug.Log("Item " + gameObject.name + " Selected");
        this.gameObject = gameObject;
        Enable(true);
    }

    public void OnUnselect(GameObject gameObject) {
        Debug.Log("Item " + gameObject.name + " Selected");
        this.gameObject = null;
        Enable(false);
    }

    private void Enable(bool enable) {
        transform.localScale = enable ? Vector3.one : Vector3.zero;
    }
}
