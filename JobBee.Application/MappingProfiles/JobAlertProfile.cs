using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.JobAlert.Commands.CreateJobAlert;
using JobBee.Application.Features.JobAlert.Queries.GetJobAlertByCandidateId;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class JobAlertProfile : Profile
	{
        public JobAlertProfile()
        {
            CreateMap<JobAlert, CreateJobAlertCommand>().ReverseMap();
            CreateMap<JobAlert, CreateJobAlertDto>().ReverseMap();

			CreateMap<Job, JobAlertDto>()
				.ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Employer.CompanyName))
				.ForMember(dest => dest.CompanyLogo, opt => opt.MapFrom(src => src.Employer.CompanyLogo))
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.JobCategory.CategoryName))
				.ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.JobType.TypeName))
				.ForMember(dest => dest.ExperienceLevelName, opt => opt.MapFrom(src => src.ExperienceLevel.LevelName))
				.ForMember(dest => dest.EducationName, opt => opt.MapFrom(src => src.MinEducation.LevelName));

		}
    }
}
