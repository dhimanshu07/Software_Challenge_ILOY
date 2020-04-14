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


        //Api/Task/{Id}/Subtask/{Id}
        [HttpPost]
        public ActionResult Post(int taskid, [FromBody]SubTaskDetail model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }

                var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
                   FirstOrDefault(m => m.TaskId == taskid);
                if (Atask == null)
                {
                    return NotFound();
                }
                var TaskDt = _mapper.Map<ServiceSubtask>(model);
                Atask.ServiceSubtask.Add(TaskDt);


                var k = _taskcontext.Tasks.FirstOrDefault(m=>m.TaskId == taskid);
                var list = k.ServiceSubtask.ToList();
                foreach( var i in list.Select(e=>e.State ).ToList())
                {
                    if (i == "Completed" || i == "completed")
                    {
                        Atask.State = "Completed";
                    }
                    else if (i == "inProgress" || i == "InProgress" || i == "inprogress" || i == "Inprogress")
                    {
                        Atask.State = "inProgress";
                    }
                    else
                    {
                        Atask.State = "Planned";
                    }
                                 
                    
                }
                _taskcontext.SaveChanges();



                return Ok("Created Successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }

        //Api/Task/{Id}/Subtask/{Id}

        [HttpGet]
        public ActionResult Get(int taskid)
        {
            try
            {
                var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
              FirstOrDefault(m => m.TaskId == taskid);
                if (Atask == null)
                {
                    return NotFound();
                }
                var TaskDt = _mapper.Map<List<SubTaskDetail>>(Atask.ServiceSubtask);
                var update = _taskcontext.Tasks.Include(m => m.ServiceSubtask).FirstOrDefault(m => m.TaskId == taskid);
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
                return Ok(TaskDt);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }


        //Api/Task/{Id}/Subtask/{Id}
        [HttpGet("{subtaskid}")]
         public ActionResult<SubTaskDetail> Get(int taskid,int subtaskid)
         {
            try {
                var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
                     FirstOrDefault(m => m.TaskId == taskid);
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

                var update = _taskcontext.Tasks.Include(m => m.ServiceSubtask).FirstOrDefault(m => m.TaskId == taskid);
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


                return Ok(sTask);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
           
         }


        //Api/Task/{ID}/Subtask
        [HttpDelete]
        public ActionResult  Delete(int taskid)
        {
            try
            {
                var Atask = _taskcontext.Tasks.Include(m => m.ServiceSubtask).
         FirstOrDefault(m => m.TaskId == taskid);
                if (Atask == null)
                {
                    return NotFound();
                }
                _taskcontext.SubTasks.RemoveRange(Atask.ServiceSubtask);
                _taskcontext.SaveChanges();
                return Ok("Deleted All Subtasks");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
       
        }

        //Api/Task/{ID}/Subtask/{Id}

        [HttpDelete("{subtaskid}")]
        public ActionResult Delete(int taskid,int subtaskid)
        {
            try {
                var Atask = _taskcontext.SubTasks. FirstOrDefault(m => m.SubTaskId == subtaskid);
                if (Atask == null)
                {
                    return NotFound();
                }
                _taskcontext.SubTasks.Remove(Atask);


                var update = _taskcontext.Tasks.Include(m => m.ServiceSubtask).FirstOrDefault(m => m.TaskId == taskid);
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
                return Ok("Deleted Successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");

            }
         
        }

        //Api/Task/{ID}/Subtask/{Id}

        [HttpPut("{id}")]
        public ActionResult put(int taskid,int id, [FromBody]SubTaskDetail task)
        {
            try {
                var Atask = _taskcontext.Tasks.Include(m=>m.ServiceSubtask)
            .FirstOrDefault(s => s.TaskId == taskid);

                if (Atask == null)
                {
                    return NotFound();
                }

                var update = Atask.ServiceSubtask.FirstOrDefault(l => l.SubTaskId == id);
                if (update == null)
                {
                    return NotFound();
                }


                update.Name = task.Name;
                update.Description = task.Description;
                update.StartDate = task.StartDate;
                update.FinishDate = task.FinishDate;
                update.State = task.State;

                var k = _taskcontext.Tasks.Include(m => m.ServiceSubtask).FirstOrDefault(m => m.TaskId.Equals(taskid));
                var list = k.ServiceSubtask.ToList();
                foreach (var i in list.Select(e => e.State).ToList())
                {
                    if (i == "Completed" || i == "completed")
                    {
                        Atask.State = "Completed";
                    }
                    else if (i == "inProgress"|| i == "InProgress"|| i == "inprogress"|| i == "Inprogress")
                    {
                        Atask.State = "inProgress";
                    }
                    else
                    {
                        Atask.State = "Planned";
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


    }
}
