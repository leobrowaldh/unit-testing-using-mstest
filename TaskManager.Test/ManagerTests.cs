namespace TaskManager.Test
{
	[TestClass]
	public class ManagerTests
	{
		[TestMethod]
		public void TestAddTaskIDUniqueness_ShouldReturnTrue()
		{
			//Arrange
			Manager manager = new Manager();
			string name1 = "task1";
			string name2 = "task2";
			string description1 = "important task";
			string description2 = "unimportant task";

			//Act

			manager.AddTask(name1, description1);
			manager.AddTask(name2, description2);

			//Assert
			Assert.AreNotEqual(manager.Tasks[0].Id, manager.Tasks[1].Id);
		}

		[TestMethod]
		public void TestAddTaskNewTaskCreatedNotNullAndISCompleteFalse()
		{
			//Arrange
			Manager manager = new Manager();
			string name1 = "task1";
			string description1 = "important task";

			//Act

			Task task1 = manager.AddTask(name1, description1);

			//Assert
			Assert.IsNotNull(manager.Tasks[0]);
			Assert.IsFalse(manager.Tasks[0].IsCompleted);
		}

		[TestMethod]
		public void TestCompleteTask_ShouldReturnTrue()
		{
			//Arrange
			Manager manager = new Manager();
			string name1 = "task1";
			string description1 = "important task";
			Task task1 = manager.AddTask(name1, description1);

			//Act
			manager.CompleteTask(task1.Id);

			//Assert
			Assert.IsTrue(task1.IsCompleted);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "Task woth given id should not have existed.")]
		public void TestCompleteTask_ShouldThrowExceptionIfNoTaskWithGivenIdExists()
		{
			//Arrange
			Manager manager = new Manager();

			//Act
			manager.CompleteTask(99);

			//Assert
		}

		[TestMethod]
		public void TestGetAllTasks_()
		{
			//Arrange
			Manager manager = new Manager();
			string name1 = "task1";
			string name2 = "task2";
			string description1 = "important task";
			string description2 = "unimportant task";
			Task task1 = manager.AddTask(name1, description1);
			Task task2 = manager.AddTask(name2, description2);

			//Act
			List<Task> listOfTasks = manager.GetAllTasks();

			//Assert
			Assert.AreEqual(2, listOfTasks.Count);
			Assert.AreEqual(listOfTasks.FirstOrDefault(t => t.Name.Equals("task1")).Description, "important task");
			Assert.AreEqual(listOfTasks.FirstOrDefault(t => t.Name.Equals("task2")).Description, "unimportant task");
		}

		[TestMethod]
		public void TestGetAllTasks_EmptyList()
		{
			//Arrange
			Manager manager = new Manager();

			//Act
			List<Task> listOfTasks = manager.GetAllTasks();

			//Assert
			Assert.IsNotNull(listOfTasks);
			Assert.AreEqual(listOfTasks.Count, 0);
		}

		[TestMethod]
		public void GetAllIncompleteTasks_ShouldReturnEmptyListIfNothingIncomplete()
		{
			//Arrange
			Manager manager = new Manager();
			string name1 = "task1";
			string description1 = "important task";
			Task task1 = manager.AddTask(name1, description1);
			manager.CompleteTask(task1.Id);

			//Act
			List<Task> listOfTasks = manager.GetAllIncompleteTasks();

			//Assert
			Assert.AreEqual(listOfTasks.Count, 0);
		}

		[TestMethod]
		public void GetAllIncompleteTasks_ShouldReturnCorrectNumberOfIncompleteTasks()
		{
			//Arrange
			Manager manager = new Manager();
			string name1 = "task1";
			string description1 = "important task";
			Task task1 = manager.AddTask(name1, description1);
			string name2 = "task2";
			string description2 = "unimportant task";
			Task task2 = manager.AddTask(name2, description2);
			manager.CompleteTask(task2.Id);

			//Act
			List<Task> listOfTasks = manager.GetAllIncompleteTasks();

			//Assert
			Assert.AreEqual(listOfTasks.Count, 1);
			Assert.AreEqual(listOfTasks[0].Id, task1.Id);
			Assert.IsFalse(listOfTasks[0].IsCompleted);
		}

		[TestMethod]
		public void GetAllIncompleteTasks_ShouldReturnAllTasksIfAllIncomplete()
		{
			//Arrange
			Manager manager = new Manager();
			string name1 = "task1";
			string description1 = "important task";
			Task task1 = manager.AddTask(name1, description1);
			string name2 = "task2";
			string description2 = "unimportant task";
			Task task2 = manager.AddTask(name2, description2);

			//Act
			List<Task> listOfTasks = manager.GetAllIncompleteTasks();

			//Assert
			Assert.AreEqual(listOfTasks.Count, 2);
		}
	}
}