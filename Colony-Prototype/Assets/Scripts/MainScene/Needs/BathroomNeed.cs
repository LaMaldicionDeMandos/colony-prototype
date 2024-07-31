using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BathroomNeed : Mortal {
    private static float I_NEED_TO_GO = 33.33f;
    private static float I_VERY__NEED_TO_GO = 8.33f;
    private static float ZERO = 0.0f;
    private static float UNIT_TIME_IN_SECONDS = 8*60;

    public float needToGo = 100.0f;

    void Update() {
        CalculateNeed(Time.deltaTime);
        CalculateLocalTaskByNeed();
    }

    private void CalculateLocalTaskByNeed() {
        if (needToGo < ZERO) ShouldPeed();
        else if (needToGo < I_VERY__NEED_TO_GO) VeryNeedToGo();
        else if (needToGo < I_NEED_TO_GO) NeedToGo();
    }

    private void SendTask(Task task) {
        ExecuteEvents.Execute<LocalTaskEventHandler>(gameObject, null, (x, y) => x.OnTask(task));
    }

    private void ShouldPeed() {
        SendTask(new BathroomTask(TaskPriority.HIGHEST));
    }

    private void VeryNeedToGo() {
        SendTask(new BathroomTask(TaskPriority.HIGH));
    }

    private void NeedToGo() {
        SendTask(new BathroomTask());
    }

    private void CalculateNeed(float dt) {
        needToGo-= dt/UNIT_TIME_IN_SECONDS;
    }
}
