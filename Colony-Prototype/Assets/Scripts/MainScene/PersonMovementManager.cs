using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovementManager : MonoBehaviour {
    private static int PRIMARY_MOUSE_BUTTON = 0;

    private Movement[] movementComponents;
    void Start() {
        movementComponents = GetComponents<Movement>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(PRIMARY_MOUSE_BUTTON)) {
            Vector3 mousePosition =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 direction = Vector3.Normalize(mousePosition - transform.position); 
            Debug.Log("Me muevo mi posicion " + transform.position + " -- Hasta: " + mousePosition + " -- Direccion: " + direction);
            foreach (Movement component in movementComponents) {
                Debug.Log("Ir hacia: " + direction);
                component.UpdateDirection(direction);
            }
        }
    }
}
