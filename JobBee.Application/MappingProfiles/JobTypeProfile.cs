using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.JobType.Commands.CreateJobType;
using JobBee.Application.Features.JobType.Commands.UpdateJobType;
using JobBee.Application.Features.JobType.Queries.GetAllJobType;
using JobBee.Application.Features.JobType.Queries.GetJobTypeDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class JobTypeProfile : Profile
	{
        public JobTypeProfile()
        {
            CreateMap<JobType, CreateJobTypeDto>().ReverseMap();
            CreateMap<JobType, CreateJobTypeCommand>().ReverseMap();

            CreateMap<JobType, UpdateJobTypeDto>().ReverseMap();
            CreateMap<JobType, UpdateJobTypeCommand>().ReverseMap();

            CreateMap<JobType, JobTypeDto>().ReverseMap();

            CreateMap<JobType, JobTypeDetailDto>().ReverseMap();
        }
    }
}
