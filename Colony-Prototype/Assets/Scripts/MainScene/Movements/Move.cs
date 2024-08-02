using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour, Movement {
    public float Speed = 2.0f;
    private Vector3 currentDirection = Vector3.zero;

    void Start() {}

    void Update() {
        float scaleFactor = Speed*Time.deltaTime;
        Vector3 scaledDirection = Vector3.Scale(currentDirection, new Vector3(scaleFactor, scaleFactor, 0));
        transform.position+= scaledDirection;
    }

    public void UpdateDirection(Vector3 direction) {
        currentDirection = direction;        
    } 
}
