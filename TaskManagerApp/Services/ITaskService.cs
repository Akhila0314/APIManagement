using System.Collections.Generic;
using TaskManagerApp.Models;


namespace TaskManagerApp.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskData> GetList();
        TaskData AddTask(TaskData data);
        void DeleteTask(int id); 
    }

   
}