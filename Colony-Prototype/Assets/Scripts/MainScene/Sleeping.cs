using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeping : MonoBehaviour {
    PersonState personState;
    SpriteRenderer spriteRenderer;
    void Start() {
        personState = GetComponentInParent<PersonState>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (personState != null && personState.sleeping) {
            Sleep();
        } else {
            WakeUp();
        }
    }

    private void Sleep() {
        spriteRenderer.enabled = true;
    }

    private  void WakeUp() {
        spriteRenderer.enabled = false;
    }
}
