using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementService.DBContext.Entities;

namespace TaskManagementService.DBContext
{
    public class TaskContext : DbContext
    {
        public DbSet<ServiceTask> Tasks { get; set; }
        public DbSet<ServiceSubtask> SubTasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ServiceTask>().HasData(
               new
               {
                   TaskId = 1,
                   Name = "Clothing",
                   Description = "Clothes Package",
                   StartDate = DateTime.Now,
                   FinishDate = DateTime.Now,
                   State = ServiceTask.CurrentState.IN_PROGRESS



               },
                 new
                 {
                     TaskId = 2,
                     Name = "Dresses",
                     Description = "Bride Dress",
                     StartDate = DateTime.Now,
                     FinishDate = DateTime.Now,
                     State = ServiceTask.CurrentState.IN_PROGRESS


                 });

            modelBuilder.Entity<ServiceSubtask>().HasData(
                new 
                {
                    SubTaskId = 1,
                    TaskId = 1,
                    Name = "d",
                    Description = "d Package",
                    StartDate = DateTime.Now,
                    FinishDate = DateTime.Now,
                    State = ServiceSubtask.CurrentState.PLANNED


                },
                new 
                {
                    SubTaskId = 2,
                    TaskId = 1,
                    Name = "c",
                    Description = "c Package",
                    StartDate = DateTime.Now,
                    FinishDate = DateTime.Now,
                    State = ServiceSubtask.CurrentState.IN_PROGRESS


                
                },
                 new
                 {
                     SubTaskId = 3,
                     TaskId = 2,
                     Name = "a",
                     Description = "a Package",
                     StartDate = DateTime.Now,
                     FinishDate = DateTime.Now,
                     State = ServiceSubtask.CurrentState.PLANNED



                 },
                  new
                  {
                      SubTaskId = 4,
                      TaskId = 2,
                      Name = "b",
                      Description = "b Package",
                      StartDate = DateTime.Now,
                      FinishDate = DateTime.Now,
                      State = ServiceSubtask.CurrentState.PLANNED



                  });


           
        }

    }
}
