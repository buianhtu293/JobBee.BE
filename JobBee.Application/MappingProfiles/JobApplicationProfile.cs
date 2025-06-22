using AutoMapper;
using JobBee.Application.Features.JobApplication.Commands.CreateJobAppliaction;
using JobBee.Application.Features.JobApplication.Commands.UpdateJobApplication;
using JobBee.Application.Features.JobApplication.Queries.GetJobAppicationByCandidateId;
using JobBee.Application.Features.JobApplication.Queries.GetJobApplicationByJobId;
using JobBee.Application.Features.JobCategory.Commands.UpdateJobCategory;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class JobApplicationProfile : Profile
	{
		public JobApplicationProfile()
		{
			CreateMap<JobApplication, CreateJobApplicationCommand>().ReverseMap();
			CreateMap<JobApplication, CreateJobApplicationDto>().ReverseMap();

			CreateMap<JobApplication, UpdateJobCategoryCommand>().ReverseMap();
			CreateMap<JobApplication, UpdateJobApplicationDto>().ReverseMap();

			CreateMap<Job, JobAppliedDto>()
				.ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Employer.CompanyName))
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.JobCategory.CategoryName))
				.ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.JobType.TypeName))
				.ForMember(dest => dest.ExperienceLevelName, opt => opt.MapFrom(src => src.ExperienceLevel.LevelName))
				.ForMember(dest => dest.EducationName, opt => opt.MapFrom(src => src.MinEducation.LevelName));

			CreateMap<Candidate, CandidateAppliedDto>()
				.ForMember(dest => dest.UserName, otp => otp.MapFrom(src => src.User.UserName));

		}
	}
}
