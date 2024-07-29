using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocalTaskManager : MonoBehaviour, LocalTaskEventHandler {
    private List<Task> tasks = new List<Task>();
    void Start() {}

    void Update() {}

    public void OnTask(Task task) {
        if (CanAddTask(task)) {
            tasks.Add(task);
            Debug.Log("Add task " + task.name);
        }
    }

    private bool CanAddTask(Task task) {
        return task.unique ? CanAddUniqueTask(task) : CanAddMultiTask(task);
    }

    private bool CanAddUniqueTask(Task task) {
        return !tasks.Any(t => t.name == task.name && t.priority >= task.priority);
    }

    private bool CanAddMultiTask(Task task) {
        return !tasks.Any(t => t.unique && t.name == task.name && t.priority >= task.priority);
    }
}
