using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovementManager : MonoBehaviour {
    private static int PRIMARY_MOUSE_BUTTON = 0;

    private AbstractMovement[] movementComponents;
    void Start() {
        movementComponents = GetComponents<AbstractMovement>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(PRIMARY_MOUSE_BUTTON)) {
            Vector3 mousePosition =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 direction = Vector3.Normalize(mousePosition - transform.position); 
            Debug.Log("Me muevo mi posicion " + transform.position + " -- Hasta: " + mousePosition + " -- Direccion: " + direction);
            foreach (AbstractMovement component in movementComponents) {
                Debug.Log("Ir hacia: " + direction);
                component.UpdateDirection(direction);
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SetCurrentState(MovementState.LEFT_WALK);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            SetCurrentState(MovementState.UP_WALK);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            SetCurrentState(MovementState.DOWN_WALK);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SetCurrentState(MovementState.RIGHT_WALK);
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            SetCurrentState(MovementState.STAND);
        } 
        */       
    }
}
