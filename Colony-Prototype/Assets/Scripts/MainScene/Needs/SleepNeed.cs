using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SleepNeed : Mortal {
    private static float IM_SLEEPY = 88.0f;
    private static float IM_VERY_SLEEPY = 68.0f;
    private static float ZERO = 0.0f;
    private static float UNIT_TIME_IN_SECONDS = 30*60;

    public float dream = 0.0f;

    void Update() {
        CalculateSleep(Time.deltaTime);
        CalculateLocalTaskBySleep();
    }

    private void CalculateLocalTaskBySleep() {
        if (dream < ZERO) ShouldSleep();
        else if (dream < IM_VERY_SLEEPY) imVerySleepy();
        else if (dream < IM_SLEEPY) imSleepy();
    }

    private void ShouldSleep() {
        ExecuteEvents.Execute<LivingBeingEventHandler>(gameObject, null, (x, y) => x.Sleep());
    }

    private void imVerySleepy() {
        ExecuteEvents.Execute<LivingBeingEventHandler>(gameObject, null, (x, y) => x.ImVerySleepy());
    }

    private void imSleepy() {
        ExecuteEvents.Execute<LivingBeingEventHandler>(gameObject, null, (x, y) => x.ImSleepy());
    }

    private void CalculateSleep(float dt) {
        dream-= dt/UNIT_TIME_IN_SECONDS;
    }
}
