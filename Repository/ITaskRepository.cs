using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementService.DBContext.Entities;

namespace TaskManagementService.Repository
{
    public interface ITaskRepository
    {

        IEnumerable<ServiceTask> GetTasks();

        ServiceTask GetTaskById(int TaskId);

        void InsertTask(ServiceTask serviceTask);
        void DeleteTask(int TaskId);
        void UpdateTask(ServiceTask serviceTask);
        void Save();
    }
}
