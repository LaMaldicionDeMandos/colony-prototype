using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimarion : Movement {

    private Animator animator;
    // Start is called before the first frame update
    protected override void Start() {
        animator = GetComponent<Animator>();
        base.Start();
    }

    protected override void ChangeState(MovementState state) {
        foreach (MovementState _state in states) {
            animator.SetBool(_state.ToFriendlyString(), _state == state);
        }
    } 
}
