// Repositories/TaskRepository.cs
public class TaskRepository : ITaskRepository
{
    public List<Task> _tasks = new List<Task>
     {
        new Task { Id=1,Title="A",IsCompleted=0},
        new Task { Id = 2, Title = "B", IsCompleted = 1 },
        new Task { Id = 3, Title = "C", IsCompleted =1  }
    };
    
    public Task GetTaskById(int taskId)
    {
        return _tasks.FirstOrDefault(task => task.Id == taskId);
    }
    
    public IEnumerable<Task> GetAllTasks()
    {
        return _tasks;
    }
    
    public Task CreateTask(Task task)
    {
        task.Id = _tasks.Count + 1;
        _tasks.Add(task);
        return task;
    }
    
    public Task UpdateTask(Task task)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.IsCompleted = task.IsCompleted;
            return existingTask;
        }
        return null;
    }
    
    public void DeleteTask(int taskId)
    {
        var taskToRemove = _tasks.FirstOrDefault(task => task.Id == taskId);
        if (taskToRemove != null)
        {
            _tasks.Remove(taskToRemove);
        }
    }
}
