using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour {
    private static int PRIMARY_MOUSE_BUTTON = 0;
    private ItemSpecManager itemSpecManager;
    
    public GameObject Panel;

    private List<ItemInventory> inventory;
    void Start() {
        itemSpecManager = new ItemSpecManager();
        inventory = new List<ItemInventory> { new ItemInventory(itemSpecManager.items[0], 10), new ItemInventory(itemSpecManager.items[1], 5)};
        ExecuteEvents.Execute<IUpdateInventoryEvent>(Panel, null, (x, y) => x.StartInventory(inventory));        
    }

    void Update() {
        if (Input.GetMouseButtonDown(PRIMARY_MOUSE_BUTTON)) {
            inventory[1].amount+=3;
        }
    }
}
