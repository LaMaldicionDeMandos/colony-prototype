using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingBeingBase : MonoBehaviour, LivingBeingEventHandler {
    public virtual void Die() {}
    public virtual void Faint() {}
}
