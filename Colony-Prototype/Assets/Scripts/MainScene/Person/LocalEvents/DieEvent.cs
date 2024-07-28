using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface DieEvent : IEventSystemHandler {
    void Die();
}
