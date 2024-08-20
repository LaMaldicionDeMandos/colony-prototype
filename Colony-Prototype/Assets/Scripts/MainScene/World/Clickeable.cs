using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickeable : MonoBehaviour, ClickableHandler {
    public string type;    

    private SpriteRenderer selectedItem;

    void Start() {
        GameObject selectedItemObject = transform.Find("SelectedItem").gameObject;
        selectedItem = selectedItemObject.GetComponent<SpriteRenderer>();
    }

    void Update() {}

    public void OnClick(GameObject gameObject) {
        Debug.Log("Me hicieron click?");
        selectedItem.enabled = gameObject == transform.gameObject;
    }
}
