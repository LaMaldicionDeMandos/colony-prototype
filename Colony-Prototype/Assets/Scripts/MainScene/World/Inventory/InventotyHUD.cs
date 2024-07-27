using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventotyHUD : MonoBehaviour, IUpdateInventoryEvent {
    private static string INVENTORY_ITEM_NAME = "InventoryItemcomponent";
    private GameObject prefab;
    private static Vector2 DEFAULT_POSITION = new Vector2(96.0f, -8.0f);
    private static Vector2 DEFAULT_SIZE = new Vector2(192.0f, 20.0f);
    private static Vector2 DEFAULT_ANCHOR = new Vector2(0.0f, 1.0f);
    private static Vector3 DEFAULT_SCALE = new Vector3(1.0f, 1.0f, 1.0f);
    private List<ItemInventory> inventory;

    private List<GameObject> itemComponents;
    void Start() {
        prefab = Resources.Load<GameObject>(INVENTORY_ITEM_NAME);
    }

    void Update() {}

    public void StartInventory(List<ItemInventory> items) {
        inventory = items;
        itemComponents = new List<GameObject>();
        for( int i = 0; i < items.Count; i++) {
            Debug.Log("Item " + items[i].name + ": " + items[i].amount);
            GameObject itemComponent = createItemComponent(items[i], i);
            itemComponents.Add(itemComponent);
        }
    }

    private GameObject createItemComponent(ItemInventory item, int index) {
        if (prefab != null) {
            GameObject itemRow = Instantiate(prefab);
            itemRow.transform.SetParent(gameObject.transform);
            InventoryItemComponent component = itemRow.GetComponent<InventoryItemComponent>();
            component.itemInventory= item;
            
            RectTransform rect = itemRow.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(DEFAULT_POSITION.x, DEFAULT_POSITION.y - DEFAULT_SIZE.y*index);
            rect.sizeDelta = DEFAULT_SIZE;
            rect.anchorMin = DEFAULT_ANCHOR;
            rect.anchorMax = DEFAULT_ANCHOR;
            rect.localScale = DEFAULT_SCALE;
            return itemRow;
        }
        return null;
    }
}
