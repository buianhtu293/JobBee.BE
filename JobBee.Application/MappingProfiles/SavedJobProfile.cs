using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.JobApplication.Queries.GetJobAppicationByCandidateId;
using JobBee.Application.Features.SavedJob.Commands.CreateSavedJob;
using JobBee.Application.Features.SavedJob.Queries.GetSavedJobByCandidateId;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class SavedJobProfile : Profile
	{
        public SavedJobProfile()
        {
            CreateMap<SavedJob, CreateSavedJobCommand>().ReverseMap();
            CreateMap<SavedJob, CreateSavedJobDto>().ReverseMap();

			CreateMap<Job, SavedJobDto>()
				.ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Employer.CompanyName))
				.ForMember(dest => dest.CompanyLogo, opt => opt.MapFrom(src => src.Employer.CompanyLogo))
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.JobCategory.CategoryName))
				.ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.JobType.TypeName))
				.ForMember(dest => dest.ExperienceLevelName, opt => opt.MapFrom(src => src.ExperienceLevel.LevelName))
				.ForMember(dest => dest.EducationName, opt => opt.MapFrom(src => src.MinEducation.LevelName));
		}
    }
}
