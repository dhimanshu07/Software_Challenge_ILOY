using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementService.DBContext;
using TaskManagementService.Models;

namespace TaskManagementService.Controllers
{
    [Route("api/Task/Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly TaskContext _taskcontext;
        public ReportController(TaskContext taskcontext)
        {
            _taskcontext = taskcontext;
        }

        //GET: api/Report
        [HttpGet]
       [Produces("text/csv")]
        public ActionResult GetAll()
        {
            var Atask = _taskcontext.Tasks.Where(m => m.State == "Inprogress").ToList();

            if (Atask == null)
            {
                return NotFound();
            }
            return Ok(Atask);
          
        }




    }


}
