using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeping : MonoBehaviour {
    PersonState personState;
    SpriteRenderer renderer;
    void Start() {
        personState = GetComponentInParent<PersonState>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (personState != null && personState.sleeping) {
            Sleep();
        } else {
            WakeUp();
        }
    }

    private void Sleep() {
        renderer.enabled = true;
    }

    private  void WakeUp() {
        renderer.enabled = false;
    }
}
