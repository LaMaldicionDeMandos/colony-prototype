using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour {
    private ItemInventorySpecManager itemSpecManager;
    
    public GameObject Panel;

    private List<ItemInventory> inventory;
    void Start() {
        itemSpecManager = new ItemInventorySpecManager();
        inventory = new List<ItemInventory> { 
            new ItemInventory(itemSpecManager.items[0], 10), 
            new ItemInventory(itemSpecManager.items[1], 5),
            new ItemInventory(itemSpecManager.items[2], 20)
        };
        ExecuteEvents.Execute<IUpdateInventoryEvent>(Panel, null, (x, y) => x.StartInventory(inventory));        
    }

    void Update() {}
}
