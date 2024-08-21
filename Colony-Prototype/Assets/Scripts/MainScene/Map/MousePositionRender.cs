using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MousePositionRender : MonoBehaviour {
    private TMP_Text labelText;
    void Start() {
        labelText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 mousePosition = GetMousePosition();
        if (mousePosition != null) {
            labelText.text = $"({Mathf.FloorToInt(mousePosition.x)}, {Mathf.FloorToInt(mousePosition.y)})";
        }    
    }

    private Vector3 GetMousePosition() {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance)) {
            return ray.GetPoint(distance);
        }
        return mousePosition;
    }
}
