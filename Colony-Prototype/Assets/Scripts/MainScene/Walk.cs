using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

    private static string LEFT_WALK = "left_walk";
    private static string UP_WALK = "up_walk";
    private static string RIGHT_WALK = "right_walk";
    private static string DOWN_WALK = "down_walk";
    private static string STAND = "stand";
    private static string[] states = new string[] {LEFT_WALK, UP_WALK, RIGHT_WALK, DOWN_WALK, STAND};

    private Animator animator;
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = STAND;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SetAnimationState(LEFT_WALK);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            SetAnimationState(UP_WALK);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            SetAnimationState(DOWN_WALK);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SetAnimationState(RIGHT_WALK);
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            SetAnimationState(STAND);
        }
    }

    private void SetAnimationState(string state) {
        foreach (string _state in states) {
            animator.SetBool(_state, _state == state);
        }
        currentState = state;
    } 
}
