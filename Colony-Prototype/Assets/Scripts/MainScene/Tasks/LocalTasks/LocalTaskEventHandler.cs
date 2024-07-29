using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface LocalTaskEventHandler : IEventSystemHandler {
    void OnTask(Task task);

}
