using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementService.Models;

namespace TaskManagementService.DBContext.Entities
{
    public class ServiceTask
    {
        [Key]

        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public string State { get; set; }
        public virtual IList<ServiceSubtask> ServiceSubtask { get; set; }

       

        public class CurrentState
        {
            public const string PLANNED = "Planned";
            public const string IN_PROGRESS = "inProgress";
            public const string COMPLETED = "Completed";
        }

    }
}
