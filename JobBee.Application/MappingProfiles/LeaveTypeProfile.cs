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
			CreateMap<LeaveType, LeaveTypeDto>()
			.ForMember(dest => dest.DateCreated,
				opt => opt.MapFrom(src =>
					src.DateCreated.HasValue ? new DateTimeOffset(src.DateCreated.Value).ToUnixTimeSeconds() : (long?)null))
			.ForMember(dest => dest.DateModified,
				opt => opt.MapFrom(src =>
					src.DateModified.HasValue ? new DateTimeOffset(src.DateModified.Value).ToUnixTimeSeconds() : (long?)null));

			CreateMap<LeaveType, LeaveTypeDetailDto>();
			CreateMap<CreateLeaveTypeCommand, LeaveType>();
			CreateMap<UpdateLeaveTypeCommand, LeaveType>();
		}
	}
}
