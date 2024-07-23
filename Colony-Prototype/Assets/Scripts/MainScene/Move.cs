using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Movement, AbstractMovement {
    public float Speed = 1.0f;
    private Vector3 currentDirection = new Vector3(0.0f, 0.0f, 0.0f);

    protected override void Start() {
        base.Start();
    }

    protected override void UpdateState() {
        if (currentState != MovementState.STAND) MoveByState(currentState); 
    } 

    private void MoveByState(MovementState state) {
        float moveX = 0.0f;
        float moveY = 0.0f;
        if (state == MovementState.RIGHT_WALK) moveX = Speed*Time.deltaTime;
        if (state == MovementState.LEFT_WALK) moveX = -Speed*Time.deltaTime;
        if (state == MovementState.UP_WALK) moveY = Speed*Time.deltaTime;
        if (state == MovementState.DOWN_WALK) moveY = -Speed*Time.deltaTime; 
        MoveDelta(moveX, moveY);
    }

    private void MoveDelta(float dx, float dy) {
        transform.position+= new Vector3(dx, dy, 0.0f);
    }

    void Update() {
        float scaleFactor = Speed*Time.deltaTime;
        Vector3 scaledDirection = Vector3.Scale(currentDirection, new Vector3(scaleFactor, scaleFactor, 0));
        transform.position+= scaledDirection;
    }

    public void UpdateDirection(Vector3 direction) {
        currentDirection = direction;        
    } 
}
