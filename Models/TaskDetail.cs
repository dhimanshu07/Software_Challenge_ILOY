using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementService.DBContext.Entities;
using static TaskManagementService.DBContext.Entities.ServiceTask;

namespace TaskManagementService.Models
{
    public class TaskDetail
    {

        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FinishDate { get; set; }

        public string State { get; set; }
      //  public IList<SubTaskDetail> ServiceSubtask { get; set; }
    }
}
