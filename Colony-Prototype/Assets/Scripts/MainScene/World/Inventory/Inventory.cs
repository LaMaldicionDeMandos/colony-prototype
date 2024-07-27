using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour {
    private ItemSpecManager itemSpecManager;
    
    public GameObject Panel;

    private List<ItemInventory> inventory;
    void Start() {
        itemSpecManager = new ItemSpecManager();
        inventory = new List<ItemInventory> { new ItemInventory(itemSpecManager.Items[0], 10)};
        ExecuteEvents.Execute<IUpdateInventoryEvent>(Panel, null, (x, y) => x.StartInventory(inventory));        
    }

    void Update() {
        
    }
}
