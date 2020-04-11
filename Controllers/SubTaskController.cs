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

namespace TaskManagementService.Controllers
{
    [Route("api/Task/{taskid}/Subtask")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly TaskContext _taskcontext;
        private readonly IMapper _mapper;
        public SubTaskController(TaskContext taskcontext, IMapper mapper)
        {
            _taskcontext = taskcontext;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Post(int taskId, [FromBody]SubTaskDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
               FirstOrDefault(m => m.TaskId == taskId);
            if (Atask == null)
            {
                return NotFound();
            }
            var TaskDt = _mapper.Map<ServiceSubtask>(model);
            Atask.ServiceSubtask.Add(TaskDt);
            _taskcontext.SaveChanges();
            return Created($"api/Task/{taskId}", null);
        }

        [HttpGet]
        public ActionResult Get(int taskId)
        {
            var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
                FirstOrDefault(m => m.TaskId == taskId);
            if (Atask == null)
            {
                return NotFound();
            }
            var TaskDt = _mapper.Map<List<SubTaskDetail>>(Atask.ServiceSubtask);
            return Ok(TaskDt);
        }

         [HttpGet("{subtaskid}")]
         public ActionResult<SubTaskDetail> Get(int taskId,int subtaskid)
         {
             var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
                   FirstOrDefault(m => m.TaskId == taskId);
             if (Atask == null)
             {
                 return NotFound();
             }

             var Stask = Atask.ServiceSubtask.FirstOrDefault(l => l.SubTaskId == subtaskid);
            if (Stask == null)
            {
                return NotFound();
            }
             var sTask = new SubTaskDetail();
             sTask.SubTaskId = Stask.SubTaskId;
             sTask.Name = Stask.Name;
             sTask.Description = Stask.Description;
             sTask.StartDate = Stask.StartDate;
             sTask.FinishDate = Stask.FinishDate;
             sTask.State = Stask.State;

             // var Stask = _taskcontext.SubTasks.Find(subtaskid);         
             return Ok(sTask);
         }


        [HttpDelete]
        public ActionResult  Delete(int taskId)
        {
            var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
                FirstOrDefault(m => m.TaskId == taskId);
            if (Atask == null)
            {
                return NotFound();
            }
            _taskcontext.SubTasks.RemoveRange(Atask.ServiceSubtask);
            _taskcontext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{subtaskid}")]
        public ActionResult Delete(int taskId,int subtaskid)
        {
            var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
                FirstOrDefault(m => m.TaskId == taskId);
            if (Atask == null)
            {
                return NotFound();
            }

             var Stask = Atask.ServiceSubtask.FirstOrDefault(l => l.SubTaskId == subtaskid);
            _taskcontext.SubTasks.Remove(Stask);
            _taskcontext.SaveChanges();
            return NoContent();
        }


        [HttpPut("{id}")]
        public ActionResult UpdateSubTask(int id, [FromBody]SubTaskDetail task)
        {
            var dbTask = _taskcontext.SubTasks
         .FirstOrDefault(s => s.SubTaskId.Equals(id));

            dbTask.Name = task.Name;
            dbTask.Description = task.Description;
            dbTask.StartDate = task.StartDate;
            dbTask.FinishDate = task.FinishDate;
            dbTask.State = task.State;


            _taskcontext.SaveChanges();

            return Ok(dbTask);
        }


    }
}
