using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mortal : LivingBeingBase {
    protected virtual void Start() {
        ILivingBeingState state = GetComponent<ILivingBeingState>();
        if (state.IsDied()) {
            this.enabled = false;
        }
    }

    public override void Die() {
        this.enabled = false;
    }
}
