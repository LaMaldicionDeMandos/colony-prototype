using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSelectionManager : MonoBehaviour {
    private GameObject currentObject;
    void Start() { }

    void Update() {
       if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject()) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Clickable")) {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Has clickeado en: " + clickedObject.name);
                if (currentObject != null) TellClick(clickedObject, currentObject);
                currentObject = clickedObject;
                TellClick(currentObject, currentObject);

            } else {
                if (currentObject != null) TellClick(null, currentObject);
                currentObject = null;
            }
        }
    }

    private void TellClick(GameObject clickedObject, GameObject target) {
        ExecuteEvents.Execute<ClickableHandler>(target, null, (x, y) => x.OnClick(clickedObject));
    }

    public static bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current) {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
