using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimation : MonoBehaviour, Movement {
    private static Vector3 FORWARD_DIRECTION = Vector3.right;
    private static float MIN_UP_ANGLE = 45.0f;
    private static float MAX_UP_ANGLE = 135.0f;
    private static float MIN_DOWN_ANGLE = 225.0f;
    private static float MAX_DOWN_ANGLE = 315.0f;

    private static MovementState[] states = new MovementState[] {
        MovementState.LEFT_WALK, 
        MovementState.UP_WALK, 
        MovementState.RIGHT_WALK, 
        MovementState.DOWN_WALK, 
        MovementState.STAND
    };

    private Animator animator;
    private MovementState currentState = MovementState.STAND;
    void Start() {
        animator = GetComponent<Animator>();
    }

    private void ChangeState(MovementState state) {
        foreach (MovementState _state in states) {
            animator.SetBool(_state.ToFriendlyString(), _state == state);
        }
    }

    public void UpdateDirection(Vector3 direction) {
        if (IsStand(direction)) {
            ChangeState(MovementState.STAND);
        } else {
            MovementState state = GetDirectionByAngle(GetAngle(direction));
            if (state != currentState) ChangeState(state);
        }
    }

    private bool IsStand(Vector3 direction) {
        return direction == Vector3.zero;
    }

    private float GetAngle(Vector3 direction) {
        float angle = Vector3.Angle(FORWARD_DIRECTION, direction);
        if (direction.y < 0) angle = -1*angle + 360;
        return angle;
    } 

    private MovementState GetDirectionByAngle(float angle) {
        MovementState state = currentState;
        if (angle >= MIN_UP_ANGLE && angle <= MAX_UP_ANGLE) state = MovementState.UP_WALK;
        else if (angle >= MIN_DOWN_ANGLE && angle <= MAX_DOWN_ANGLE) state = MovementState.DOWN_WALK;
        else if (angle < MIN_UP_ANGLE || angle > MAX_DOWN_ANGLE) state = MovementState.RIGHT_WALK;
        else state = MovementState.LEFT_WALK;
        return state;
    }
}
