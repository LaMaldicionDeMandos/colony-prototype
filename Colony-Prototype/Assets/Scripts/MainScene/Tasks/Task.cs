public class Task {
    public string name;

    public bool unique;

    public TaskPriority priority;

    public Payload<object> payload;

    public Task(string name) {
        this.name = name;
        this.unique = true;
        this.payload = null;
        this.priority = TaskPriority.NORMAL;
    }

    public Task(string name, Payload<object> payload) : this(name) {
        this.payload = payload;
    }

    public Task(string name, bool unique) : this(name) {
        this.unique = unique;
    }

    public Task(string name, TaskPriority priority) : this(name) {
        this.priority = priority;
    }

    public Task(string name, Payload<object> payload, bool unique) : this(name, payload) {
        this.unique = unique;
    }

    public Task(string name, Payload<object> payload, TaskPriority priority) : this(name, payload) {
        this.priority = priority;
    }

    public Task(string name, bool unique, TaskPriority priority) : this(name, unique) {
        this.priority = priority;
    }

    public Task(string name, Payload<object> payload, bool unique, TaskPriority priority) : this(name, payload, unique) {
        this.priority = priority;
    }
}
