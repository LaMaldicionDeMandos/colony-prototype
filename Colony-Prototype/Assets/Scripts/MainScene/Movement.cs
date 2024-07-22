using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    protected static string LEFT_WALK = "left_walk";
    protected static string UP_WALK = "up_walk";
    protected static string RIGHT_WALK = "right_walk";
    protected static string DOWN_WALK = "down_walk";
    protected static string STAND = "stand";
    protected static string[] states = new string[] {LEFT_WALK, UP_WALK, RIGHT_WALK, DOWN_WALK, STAND};

    protected string currentState;
    // Start is called before the first frame update
    protected virtual void Start() {
        currentState = STAND;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SetCurrentState(LEFT_WALK);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            SetCurrentState(UP_WALK);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            SetCurrentState(DOWN_WALK);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SetCurrentState(RIGHT_WALK);
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            SetCurrentState(STAND);
        }
        UpdateState();
    }

    private void SetCurrentState(string state) {
        ChangeState(state);
        currentState = state;
    } 

    protected virtual void UpdateState() {}
    protected virtual void ChangeState(string state) {} 
}
