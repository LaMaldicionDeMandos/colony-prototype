using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirstNeed : Mortal {
    private static float MIN = -100.0f;
    private static float FAINT = -85.0f;
    private static float DELIRIUM = -67.0f;

    private static float ZERO = 0.0f;

    private static float THIRST = 50.0f;

    private static float NORMAL_UNIT_TIME_IN_SECONDS = 7*60;
    private static float ALERT_UNIT_TIME_IN_SECONDS = 42*60;

    public float thirst;

    void Update() {
        CalculateThirst(Time.deltaTime);
        CalculateLocalTaskByThirst();
    }

    private void CalculateLocalTaskByThirst() {
        if (thirst < MIN) ShuldDie();
        else if (thirst < FAINT) ShouldFaint();
        else if (thirst < DELIRIUM) Delirium();
        else if (thirst < ZERO) HasVeryThrist();
        else if (thirst < THIRST) HasThrist();
    }

    private void ShuldDie() {
        ExecuteEvents.Execute<LivingBeingEventHandler>(gameObject, null, (x, y) => x.Die());
    }

    private void ShouldFaint() {
        ExecuteEvents.Execute<LivingBeingEventHandler>(gameObject, null, (x, y) => x.Faint());
    }

    private void Delirium() {
        //Debug.Log("Delirium!");
    }

    private void HasVeryThrist() {
        //Debug.Log("Very Thrist!");
    }

    private void HasThrist() {
        //Debug.Log("Thrist");
    }

    private void CalculateThirst(float dt) {
        if (IsNormalThrist()) {
            float remain = CalculateNormalThrist(dt);
            if (remain > 0) CalculateAlertThrist(remain);
        } else {
            CalculateAlertThrist(dt);
        }
    }

    private bool IsNormalThrist() {
        return thirst > ZERO;
    }

    private float CalculateNormalThrist(float dt) {
        float dth = dt/NORMAL_UNIT_TIME_IN_SECONDS;
        float remain = ZERO;
        if ((thirst - dth >= ZERO)) {
            thirst-= dth;
        } else{
            remain = (dth - thirst)*NORMAL_UNIT_TIME_IN_SECONDS;
            thirst = ZERO;
        } 
        return remain;
    }

    private void CalculateAlertThrist(float dt) {
        thirst-= dt/ALERT_UNIT_TIME_IN_SECONDS;
    }
}
