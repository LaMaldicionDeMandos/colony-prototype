using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventotyHUD : MonoBehaviour, IUpdateInventoryEvent {
    void Start() {}

    void Update() {}

    public void StartInventory(List<ItemInventory> items) {
        foreach(ItemInventory item in items) {
            Debug.Log("Item " + item.ItemSpec.Name + ": " + item.Amount);
        }
    }
}
