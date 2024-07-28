using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mortal : MonoBehaviour, DieEventHandler {
    protected virtual void Start() {
        ILivingBeingState state = GetComponent<ILivingBeingState>();
        if (state.IsDied()) {
            this.enabled = false;
        }
    }

    public void Die() {
        this.enabled = false;
    }
}
