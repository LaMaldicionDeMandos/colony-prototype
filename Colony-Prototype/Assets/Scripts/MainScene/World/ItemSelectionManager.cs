using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectionManager : MonoBehaviour {
    void Start() { }

    void Update() {
       if (Input.GetMouseButtonDown(0)) {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null) {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Clickable")) {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Has clickeado en: " + clickedObject.name);
            }
        }
    } 
    }
}
