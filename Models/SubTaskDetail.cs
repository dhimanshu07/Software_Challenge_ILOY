﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementService.DBContext.Entities;
using static TaskManagementService.DBContext.Entities.ServiceSubtask;

namespace TaskManagementService.Models
{
    public class SubTaskDetail
    {
     //   public ServiceTask serviceTask { get; set; }
        public int SubTaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string State { get; set; }
      
    }
}
