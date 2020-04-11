using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementService.DBContext;
using TaskManagementService.DBContext.Entities;

namespace TaskManagementService.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _dbContext;
       
        public TaskRepository(TaskContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteTask(int TaskId)
        {
            var deletetask = _dbContext.Tasks.Find(TaskId);
            _dbContext.Tasks.Remove(deletetask);
            Save();
        }

        public ServiceTask GetTaskById(int TaskId)
        {
            return _dbContext.Tasks.Find(TaskId);
        }

        public IEnumerable<ServiceTask> GetTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        public void InsertTask(ServiceTask serviceTask)
        {
            _dbContext.Add(serviceTask);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateTask(ServiceTask serviceTask)
        {
           
        }
    }
}
