using System.ComponentModel.DataAnnotations;

namespace TaskManager;

public class Task
{
	public int Id { get; set; }
	public bool IsCompleted { get; set; } = false;
	public string Name { get; set; }
	public string Description { get; set; }
}
