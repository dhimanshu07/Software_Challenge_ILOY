﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementService.DBContext;
using TaskManagementService.DBContext.Entities;
using TaskManagementService.Models;
using TaskManagementService.Repository;

namespace TaskManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskContext _taskcontext;
        private readonly IMapper _mapper;
        public TaskController(TaskContext taskcontext, IMapper mapper)
        {
            _taskcontext = taskcontext;
            _mapper = mapper;
        }
        // GET: api/Task
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask);
                if (Atask == null)
                {
                    return NotFound();
                }
                var TaskDt = _mapper.Map<List<ServiceTask>>(Atask);
                return Ok(TaskDt);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
          
        }


        // GET: api/Task/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try {
                var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
              FirstOrDefault(m => m.TaskId == id);
                if (Atask == null)
                {
                    return NotFound();
                }
              //  var TaskDt = _mapper.Map<TaskDetail>(Atask);
                var update = _taskcontext.Tasks.Include(m => m.ServiceSubtask).FirstOrDefault(m => m.TaskId == id);
                var list = update.ServiceSubtask.ToList();
                foreach (var i in list.Select(e => e.State).ToList())
                {
                    if (i == "Completed" || i == "completed")
                    {
                        update.State = "Completed";
                    }
                    else if (i == "inProgress" || i == "InProgress" || i == "inprogress" || i == "Inprogress")
                    {
                        update.State = "inProgress";
                    }
                    else
                    {
                        update.State = "Planned";
                    }


                }
                return Ok(Atask);

            }
            catch(Exception ex)
            {
                return  StatusCode(500, "Internal server error");
            }
          
        }



        // POST: api/Task
        [HttpPost]
        public IActionResult Post([FromBody] TaskDetail task)
        {
            try
            {
                var dbTask = new ServiceTask();
                dbTask.Name = task.Name;
                dbTask.Description = task.Description;
                dbTask.StartDate = task.StartDate;
                dbTask.FinishDate = task.FinishDate;
                dbTask.State = task.State;
                _taskcontext.Add(dbTask);

                _taskcontext.SaveChanges();
                return Ok("Created Successfully");
            }

            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
          
        }


        // PUT: api/Task/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TaskDetail task)
        {
            try {
                var dbTask = _taskcontext.Tasks
            .FirstOrDefault(s => s.TaskId.Equals(id));

                dbTask.Name = task.Name;
                dbTask.Description = task.Description;
                dbTask.StartDate = task.StartDate;
                dbTask.FinishDate = task.FinishDate;
                dbTask.State = task.State;

                var update = _taskcontext.Tasks.Include(m => m.ServiceSubtask).FirstOrDefault(m => m.TaskId == id);
                var list = update.ServiceSubtask.ToList();
                foreach (var i in list.Select(e => e.State).ToList())
                {
                    if (i == "Completed" || i == "completed")
                    {
                        update.State = "Completed";
                    }
                    else if (i == "inProgress" || i == "InProgress" || i == "inprogress" || i == "Inprogress")
                    {
                        update.State = "inProgress";
                    }
                    else
                    {
                        update.State = "Planned";
                    }


                }


                _taskcontext.SaveChanges();

                return Ok("Updated Successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{taskId}")]
        public IActionResult Delete(int taskId)
        {
            try
            {
                var Atask = _taskcontext.Tasks.Include(k => k.ServiceSubtask).
                   FirstOrDefault(m => m.TaskId.Equals(taskId));
                if (Atask == null)
                {
                    return NotFound();
                }
                _taskcontext.Tasks.Remove(Atask);
                _taskcontext.SaveChanges();
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

    }

}
