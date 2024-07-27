using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryItemComponent : MonoBehaviour {
    public ItemInventory itemInventory;

    private TMP_Text label;
    void Start() {
        label = gameObject.transform.Find("Text").GetComponent<TMP_Text>();
    }

    void Update() {
        label.text = (itemInventory.name != null)? $"{itemInventory.name} {itemInventory.amount}" : "";
    }
}
