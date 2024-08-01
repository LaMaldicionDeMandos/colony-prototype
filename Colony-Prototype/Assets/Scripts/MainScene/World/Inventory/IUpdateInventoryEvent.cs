using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IUpdateInventoryEvent : IEventSystemHandler {
    void StartInventory(List<ItemInventory> items);
}
