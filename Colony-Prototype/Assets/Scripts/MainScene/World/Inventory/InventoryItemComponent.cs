using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemComponent : MonoBehaviour {
    public ItemInventory itemInventory;

    private TMP_Text label;

    private GameObject icon;
    private Image iconImage;
    void Start() {
        label = gameObject.transform.Find("Text").GetComponent<TMP_Text>();
        icon = gameObject.transform.Find("Icon").gameObject;
        iconImage = icon.GetComponent<Image>();
        if (itemInventory.icon != null) {
            Sprite sprite = Resources.Load<Sprite>(itemInventory.icon);
            iconImage.sprite = sprite;
        }
    }

    void Update() {
        label.text = (itemInventory.name != null)? $"{itemInventory.name} {itemInventory.amount}" : "";
        if (itemInventory.icon != null) {
            icon.SetActive(true);
        } else {
            icon.SetActive(false);
        }
    }
}
