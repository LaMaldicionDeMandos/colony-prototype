using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonState : LivingBeingBase, ILivingBeingState {
    private Quaternion DIE_ROTATION = Quaternion.Euler(0, 0, 80);
    public bool died;

    private Animator animator;
    void Start() {
        animator = GetComponent<Animator>();
        if (died) {
            SetStatusDied();
        }
    }

    void Update() {}

    public override void Die() {
        if (!died) {
            Debug.Log("I have died");
            died = true;
            SetStatusDied();
        }
    }

    public bool IsDied() {
        return died;
    }

    private void SetStatusDied() {
        animator.SetBool("die", true);
        transform.rotation = DIE_ROTATION;
    }
}
