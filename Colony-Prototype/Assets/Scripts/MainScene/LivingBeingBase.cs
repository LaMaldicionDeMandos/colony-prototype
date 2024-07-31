using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingBeingBase : MonoBehaviour, LivingBeingEventHandler {
    public virtual void Die() {}
    public virtual void Faint() {}
    public virtual void Delirium() {}

    public virtual void Sleep() {}

    public virtual void ImSleepy() {}

    public virtual void ImVerySleepy() {}

    public virtual void WakeUp() {}
}
