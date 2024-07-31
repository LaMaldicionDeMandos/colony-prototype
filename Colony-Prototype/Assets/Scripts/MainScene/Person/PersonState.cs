using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonState : MonoBehaviour, LivingBeingEventHandler, ILivingBeingState {
    private Quaternion DIE_ROTATION = Quaternion.Euler(0, 0, 80);
    public bool died;

    public bool sleeping;
    public bool imSleepy;
    public bool imVerySleepy;

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

    public void Sleep() {
        if (!sleeping) {
            Debug.Log("ZZZZZ");
            sleeping = true;
        }
    }

    public void ImSleepy() {
        if (!imSleepy) {
            Debug.Log("I'm Sleepy");
            imSleepy = true;
        }
    }

    public void ImVerySleepy() {
        if (!imVerySleepy) {
            Debug.Log("I'm very Sleepy");
            imVerySleepy = true;
        }
    }

    public void WakeUp() {
        sleeping = false;
        imSleepy = false;
        imVerySleepy = false;
    }

    public bool IsDied() {
        return died;
    }

    private void SetStatusDied() {
        animator.SetBool("die", true);
        transform.rotation = DIE_ROTATION;
    }
}
