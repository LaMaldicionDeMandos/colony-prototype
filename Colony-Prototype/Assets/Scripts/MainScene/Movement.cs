using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    protected static MovementState[] states = new MovementState[] {
        MovementState.LEFT_WALK, 
        MovementState.UP_WALK, 
        MovementState.RIGHT_WALK, 
        MovementState.DOWN_WALK, 
        MovementState.STAND
    };

    protected MovementState currentState;

    protected virtual void Start() {
        currentState = MovementState.STAND;
    }

    // Update is called once per frame
    void Update()
    {   
        UpdateState();
    }

    public void SetState(MovementState state) {
        if (currentState != state) SetCurrentState(state);
    }

    private void SetCurrentState(MovementState state) {
        ChangeState(state);
        currentState = state;
    } 

    protected virtual void UpdateState() {}
    protected virtual void ChangeState(MovementState state) {} 
}
