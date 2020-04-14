using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TaskManagementService.DBContext.Entities
{
    public class ServiceSubtask
    {
        [Key]
        public int SubTaskId { get; set; }

        [ForeignKey("TaskId")]
        [JsonIgnore]
        [IgnoreDataMember]
        public ServiceTask ServiceTask { get; set; }
        public string Name { get; set; }   
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FinishDate { get; set; }
        public string State { get; set; }

        public class CurrentState
        {
            public const string PLANNED = "Planned";
            public const string IN_PROGRESS = "inProgress";
            public const string COMPLETED = "Completed";
        }
    }
}
