using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    // Deprecated
    protected static MovementState[] states = new MovementState[] {
        MovementState.LEFT_WALK, 
        MovementState.UP_WALK, 
        MovementState.RIGHT_WALK, 
        MovementState.DOWN_WALK, 
        MovementState.STAND
    };

    // Deprecated
    protected MovementState currentState;

    protected virtual void Start() {
        //Deprecated
        currentState = MovementState.STAND;
    }

    void Update()
    {   
        UpdateState();
    }

    //Deprecated
    public void SetState(MovementState state) {
        if (currentState != state) SetCurrentState(state);
    }

    //Deprecated
    private void SetCurrentState(MovementState state) {
        ChangeState(state);
        currentState = state;
    } 

    protected virtual void UpdateState() {}
    protected virtual void ChangeState(MovementState state) {} 
}
