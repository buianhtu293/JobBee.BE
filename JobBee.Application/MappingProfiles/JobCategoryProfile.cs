using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.JobCategory.Commands.CreateJobCategory;
using JobBee.Application.Features.JobCategory.Commands.UpdateJobCategory;
using JobBee.Application.Features.JobCategory.Queries.GetAllJobCategory;
using JobBee.Application.Features.JobCategory.Queries.GetJobCategoryDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class JobCategoryProfile : Profile
	{
		public JobCategoryProfile() 
		{ 
			CreateMap<JobCategory, CreateJobCategoryCommand>().ReverseMap();
			CreateMap<JobCategory, CreateJobCategoryDto>().ReverseMap();

			CreateMap<JobCategory, UpdateJobCategoryCommand>().ReverseMap();
			CreateMap<JobCategory, UpdateJobCategoryDto>().ReverseMap();

			CreateMap<JobCategory, JobCategoryDto>().ReverseMap();

			CreateMap<JobCategory, JobCategoryDetailDto>().ReverseMap();
		}
	}
}
