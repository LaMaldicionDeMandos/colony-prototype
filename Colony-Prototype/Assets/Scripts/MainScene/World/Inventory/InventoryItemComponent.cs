using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

interface SpriteLoaderStrategy {
    Sprite LoadSprite(string spriteName);
}

class SingleSpriteLoaderStrategy : SpriteLoaderStrategy {
    public Sprite LoadSprite(string spriteName) {
        return Resources.Load<Sprite>(spriteName);
    }
}

class MultipleSpriteLoaderStrategy : SpriteLoaderStrategy {
    private char[] separators = new char[] { '.' };
    public Sprite LoadSprite(string spriteName) {
        string[] parts = spriteName.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Sprite[] sprites = Resources.LoadAll<Sprite>(parts[0]);
        return System.Array.Find(sprites, sprite => sprite.name == parts[1]); 
    }
}

public class InventoryItemComponent : MonoBehaviour {
    private static SingleSpriteLoaderStrategy singleSpriteLoader = new SingleSpriteLoaderStrategy();
    private static MultipleSpriteLoaderStrategy multipleSpriteLoader = new MultipleSpriteLoaderStrategy();
    public ItemInventory itemInventory;

    private TMP_Text label;

    private GameObject icon;
    private Image iconImage;
    void Start() {
        label = gameObject.transform.Find("Text").GetComponent<TMP_Text>();
        icon = gameObject.transform.Find("Icon").gameObject;
        iconImage = icon.GetComponent<Image>();
        if (itemInventory.icon != null) {
            Sprite sprite = GetItemSprite(itemInventory.icon);
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

    private Sprite GetItemSprite(string spriteName) {
        SpriteLoaderStrategy loader = (spriteName.Contains('.')) ? multipleSpriteLoader : singleSpriteLoader;
        return loader.LoadSprite(spriteName);
    }
}
