using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestActionHandler : MonoBehaviour, ClickableHandler {

    private GameObject harvesteable;
    void Start() {
        ItemSelectionManager.instance.Subscribe(this);
        Enable(false);
    }

    void Update() {}

    public void OnSelect(GameObject gameObject) {
        Debug.Log("Item " + gameObject.name + " Selected");
        HarvesteableComponent harvesteableComponent = gameObject.GetComponent<HarvesteableComponent>();
        if (harvesteableComponent != null) {
            harvesteable = gameObject;
            Enable(true);
            Debug.Log("Sprite: " + harvesteableComponent.GetHarvestType());
        }

    }

    public void OnUnselect(GameObject gameObject) {
        Debug.Log("Item " + gameObject.name + " Selected");
        harvesteable = null;
        Enable(false);
    }

    private void Enable(bool enable) {
        transform.localScale = enable ? Vector3.one : Vector3.zero;
    }
}
