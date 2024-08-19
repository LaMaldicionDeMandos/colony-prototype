using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Mortal, Movement {
    public float Speed = 1.0f;
    private Vector3 currentDirection = Vector3.zero;

    void Update() {
        float scaleFactor = Speed*Time.deltaTime;
        Vector3 scaledDirection = Vector3.Scale(currentDirection, new Vector3(scaleFactor, scaleFactor, 0));
        transform.position+= scaledDirection;
    }

    public void UpdateDirection(Vector3 direction) {
        currentDirection = direction;        
    } 

    public override void Sleep() {
        this.enabled = false;
    }

    public override void WakeUp() {
        this.enabled = true;
    }
}
