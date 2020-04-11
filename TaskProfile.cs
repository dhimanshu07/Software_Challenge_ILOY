using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagementService.DBContext.Entities;
using TaskManagementService.Models;

namespace TaskManagementService
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<ServiceTask, TaskDetail>();
            CreateMap<ServiceSubtask, SubTaskDetail>().ReverseMap();
            

        }
    }
}
