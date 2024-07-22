using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Movement {

    public float Speed = 1.0f;

    protected override void Start() {
        base.Start();
    }

    protected override void UpdateState() {
        if (currentState != STAND) MoveByState(currentState); 
    } 

    private void MoveByState(string state) {
        float moveX = 0.0f;
        float moveY = 0.0f;
        if (state == RIGHT_WALK) moveX = Speed*Time.deltaTime;
        if (state == LEFT_WALK) moveX = -Speed*Time.deltaTime;
        if (state == UP_WALK) moveY = Speed*Time.deltaTime;
        if (state == DOWN_WALK) moveY = -Speed*Time.deltaTime; 
        MoveDelta(moveX, moveY);
    }

    private void MoveDelta(float dx, float dy) {
        transform.position+= new Vector3(dx, dy, 0.0f);
    }
}
