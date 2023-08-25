// Repositories/ITaskRepository.cs
public interface ITaskRepository
{
    Task GetTaskById(int taskId);
    IEnumerable<Task> GetAllTasks();
    Task CreateTask(Task task);
    Task UpdateTask(Task task);
    void DeleteTask(int taskId);
}
