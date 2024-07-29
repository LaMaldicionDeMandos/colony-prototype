using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonState : MonoBehaviour, LivingBeingEventHandler, ILivingBeingState {
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

    public void Die() {
        if (!died) {
            Debug.Log("I'm died");
            died = true;
            SetStatusDied();
        }
    }

    public void Faint() {}
    public void Delirium() {}

    public bool IsDied() {
        return died;
    }

    private void SetStatusDied() {
        animator.SetBool("die", true);
        transform.rotation = DIE_ROTATION;
    }
}
