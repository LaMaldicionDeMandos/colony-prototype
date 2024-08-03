using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuAction : MonoBehaviour {
    
    void Start() {}

    void Update() {}

    public void OnOpenMenu() {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
