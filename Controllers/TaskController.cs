using System;
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
        private readonly ITaskRepository _taskRepository;
        public TaskController(TaskContext taskcontext, IMapper mapper, ITaskRepository taskRepository)
        {
            _taskcontext = taskcontext;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }
        // GET: api/Task
        [HttpGet]
        public ActionResult<TaskDetail> Get()
        {
            var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask);
            if (Atask == null)
            {
                return NotFound();
            }
            var TaskDt = _mapper.Map<List<TaskDetail>>(Atask);
            return Ok(TaskDt);
        }


        // GET: api/Task/5
        [HttpGet("{id}")]
        public ActionResult<TaskDetail> Get(int id)
        {
            var Atask = _taskcontext.Tasks.Include(m=>m.ServiceSubtask).
                FirstOrDefault(m=> m.TaskId == id);
            if(Atask == null)
            {
                return NotFound();
            }
            var TaskDt = _mapper.Map<TaskDetail>(Atask);
            return  Ok(TaskDt);
        }



        // POST: api/Task
        [HttpPost]
        public IActionResult Post([FromBody] ServiceTask task)
        {
            using (var result = new TransactionScope())
            {
                _taskRepository.InsertTask(task);
                result.Complete();
                return CreatedAtAction(nameof(Get), new { id = task.TaskId }, task);
            }
        }


        // PUT: api/Task/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody]TaskDetail task)
        {
            var dbTask = _taskcontext.Tasks
         .FirstOrDefault(s => s.TaskId.Equals(id));

            dbTask.Name = task.Name;
            dbTask.Description = task.Description;
            dbTask.StartDate = task.StartDate;
            dbTask.FinishDate = task.FinishDate;
            

            _taskcontext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{taskId}")]
        public IActionResult Delete(int taskId)
        {
            var Atask = _taskcontext.Tasks.Include(k=>k.ServiceSubtask).
                FirstOrDefault(m => m.TaskId.Equals(taskId));
            if (Atask == null)
            {
                return NotFound();
            }
            _taskcontext.Tasks.Remove(Atask);
            _taskcontext.SaveChanges();
            return Ok(Atask);
        }

    }

}
