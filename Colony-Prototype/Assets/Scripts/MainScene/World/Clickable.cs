using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour, ClickableHandler {
    public string type;    

    private SpriteRenderer selectedItem;

    void Start() {
        GameObject selectedItemObject = transform.Find("SelectedItem").gameObject;
        selectedItem = selectedItemObject.GetComponent<SpriteRenderer>();
    }

    void Update() {}

    public void OnSelect(GameObject gameObject) {
        if (gameObject == transform.gameObject) selectedItem.enabled = true;
    }

    public void OnUnselect(GameObject gameObject) {
        if (gameObject == transform.gameObject) selectedItem.enabled = false;
    }
}
