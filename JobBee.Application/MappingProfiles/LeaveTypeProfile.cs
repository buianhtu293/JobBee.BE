using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.LeaveType.Commands.CreateLeaveType;
using JobBee.Application.Features.LeaveType.Commands.UpdateLeaveType;
using JobBee.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using JobBee.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using JobBee.Domain;

namespace JobBee.Application.MappingProfiles
{
	public class LeaveTypeProfile : Profile
	{
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}
