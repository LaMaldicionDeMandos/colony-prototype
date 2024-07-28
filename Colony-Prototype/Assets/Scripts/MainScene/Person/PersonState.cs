using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonState : MonoBehaviour, DieEvent {
    private Quaternion DIE_ROTATION = Quaternion.Euler(0, 0, 80);
    public bool died;

    private Animator animator;
    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {}

    public void Die() {
        if (!died) {
            Debug.Log("I have died");
            died = true;
            animator.SetBool("die", true);
            transform.rotation = DIE_ROTATION;
        }
    }
}
