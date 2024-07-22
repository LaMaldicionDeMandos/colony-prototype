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
            Debug.Log("Me muevo mi posicion " + transform.position + " -- Hasta: " + mousePosition);
            if (mousePosition.x > transform.position.x) {
                SetCurrentState(MovementState.RIGHT_WALK);                
            } else {
                SetCurrentState(MovementState.LEFT_WALK);
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

    private void SetCurrentState(MovementState state) {
        foreach (Movement component in movementComponents) {
            component.SetState(state);
        }
    }
}
