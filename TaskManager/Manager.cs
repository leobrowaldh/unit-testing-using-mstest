namespace TaskManager;

public class Manager
{
	public List<Task> Tasks { get; set; } = [];
	private int _nextId = 1;

	public Task AddTask(string name, string description)
	{
		Task task = new Task() { Name = name, Description = description};
		task.Id = _nextId;
		_nextId++;
		Tasks.Add(task);
		return task;
	}

	public bool CompleteTask(int id)
	{
		Task? taskToComplete = Tasks.Where(t => t.Id == id).FirstOrDefault();
		if (taskToComplete != null)
		{
			taskToComplete.IsCompleted = true;
			return true;
		}

		throw new ArgumentException($"Given task Id = {id} not found");
	}

	public List<Task> GetAllTasks()
	{
		return Tasks;
	}

	public List<Task> GetAllIncompleteTasks()
	{
		return Tasks.Where(t => !t.IsCompleted).ToList();
	}
}
