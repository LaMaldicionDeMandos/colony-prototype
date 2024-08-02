using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public float velocity;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position+= new Vector3(-velocity*0.025f, 0, 0); 
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position+= new Vector3(velocity*0.025f, 0, 0); 
        }
    }
}
