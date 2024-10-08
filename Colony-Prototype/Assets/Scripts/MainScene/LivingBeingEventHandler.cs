using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface LivingBeingEventHandler : IEventSystemHandler {
    void Die();
    void Faint();

    void Delirium(); 

    void Sleep();

    void ImSleepy();

    void ImVerySleepy();

    void WakeUp();
}
