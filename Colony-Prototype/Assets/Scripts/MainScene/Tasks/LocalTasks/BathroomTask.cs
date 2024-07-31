public class BathroomTask : Task {
    public BathroomTask() : base("goToBathroom", TaskPriority.IMPORTANT) {}
    public BathroomTask(TaskPriority priority) : base("goToBathroom", priority) {}
}
