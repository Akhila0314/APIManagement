using System.Collections.Generic;
using System.Linq;
using TaskManagerApp.Controllers;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services;

    public class TaskServiceImp : ITaskService
{

    private readonly ILogger<TaskServiceImp> logger;
    public TaskServiceImp(ILogger<TaskServiceImp> log)
    {
        logger = log;
    }
    private readonly List<TaskData> tasks = new();

    public IEnumerable<TaskData> GetList() => tasks;

    public TaskData AddTask(TaskData data)
    {
        logger.LogInformation("Adding a task");
        data.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
        tasks.Add(data);
        logger.LogInformation("Task added successfully");
        return data;
    }

    public void DeleteTask(int id)
    {
        logger.LogInformation("Deleting a task");
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
            tasks.Remove(task);
            logger.LogInformation("Task deleted successfully");

        for (int i = 0; i < tasks.Count; i++)
            tasks[i].Id = i + 1;
    }

   
}

