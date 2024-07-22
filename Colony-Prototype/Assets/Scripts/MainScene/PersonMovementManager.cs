using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovementManager : MonoBehaviour {

    private Movement[] movementComponents;
    void Start() {
        movementComponents = GetComponents<Movement>();
    }

    void Update() {
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
    }

    private void SetCurrentState(MovementState state) {
        foreach (Movement component in movementComponents) {
            component.SetState(state);
        }
    }
}
