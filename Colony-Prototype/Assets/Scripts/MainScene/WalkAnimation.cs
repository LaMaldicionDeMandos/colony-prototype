using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimation : Movement, AbstractMovement {
    private static Vector3 FORWARD_DIRECTION = new Vector3(1.0f, 0.0f, 0.0f);
    private static float MIN_UP_ANGLE = 45.0f;
    private static float MAX_UP_ANGLE = 135.0f;
    private static float MIN_DOWN_ANGLE = 225.0f;
    private static float MAX_DOWN_ANGLE = 315.0f;

    private Animator animator;
    // Start is called before the first frame update
    protected override void Start() {
        animator = GetComponent<Animator>();
        base.Start();
    }

    protected override void ChangeState(MovementState state) {
        foreach (MovementState _state in states) {
            animator.SetBool(_state.ToFriendlyString(), _state == state);
        }
    }

    public void UpdateDirection(Vector3 direction) {
        MovementState state = currentState;
        if (direction.x == 0.0f && direction.y == 0 && currentState != MovementState.STAND) {
            state = MovementState.STAND;
            return;
        }
        float angle = Vector3.Angle(FORWARD_DIRECTION, direction);
        if (direction.y < 0) angle = -1*angle + 360;
        Debug.Log("Angle " + angle);
        if (angle >= MIN_UP_ANGLE && angle <= MAX_UP_ANGLE) state = MovementState.UP_WALK;
        else if (angle >= MIN_DOWN_ANGLE && angle <= MAX_DOWN_ANGLE) state = MovementState.DOWN_WALK;
        else if (angle < MIN_UP_ANGLE || angle > MAX_DOWN_ANGLE) state = MovementState.RIGHT_WALK;
        else state = MovementState.LEFT_WALK;
        if (state != currentState) ChangeState(state);
    } 
}
