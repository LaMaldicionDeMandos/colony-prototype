using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : Mortal {

    private Animator animator;
    // Start is called before the first frame update
    protected override void Start() {
        animator = GetComponent<Animator>();
        base.Start();
    }

    void Update() {
        animator.SetBool("left_walk", false);
        animator.SetBool("up_walk", false);
        animator.SetBool("right_walk", false);
        animator.SetBool("down_walk", false);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            animator.SetBool("left_walk", true);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            animator.SetBool("up_walk", true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            animator.SetBool("down_walk", true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            animator.SetBool("right_walk", true);
        }
    }
}
