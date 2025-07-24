using AutoMapper;
using JobBee.Application.Features.Job.Commands.CreateJob;
using JobBee.Application.Features.Job.Commands.UpdateJob;
using JobBee.Application.Features.Job.Queries.CommonJobs;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Application.Features.Job.Queries.GetPostedJobs;
using JobBee.Domain.Entities;
using JobBee.Shared.Paginators;
using JobBee.Shared.Ultils;

namespace JobBee.Application.MappingProfiles;

public class JobProfile : Profile
{
	public JobProfile()
	{
		CreateMap<Job, JobDto>()
			.ForMember(dest => dest.EmployerName, opt => opt.MapFrom(src => src.Employer!.CompanyName))
			.ForMember(dest => dest.CompanyLogo, opt => opt.MapFrom(src => src.Employer!.CompanyLogo))
			.ForMember(dest => dest.JobCategory, opt => opt.MapFrom(src => src.JobCategory!.CategoryName))
			.ForMember(dest => dest.JobType, opt => opt.MapFrom(src => src.JobType!.TypeName))
			.ForMember(dest => dest.JobStatus, opt => opt.MapFrom(src => src.ExpiresAt < DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() ? "expired" : "active"))
			.ForMember(dest => dest.ExperienceLevel, opt => opt.MapFrom(src => src.ExperienceLevel!.LevelName))
			.ForMember(dest => dest.MinEducationLevel, opt => opt.MapFrom(src => src.MinEducation!.LevelName));

		CreateMap<CreateJobCommand, Job>()
			.ForMember(dest => dest.EmployerId, opt => opt.Ignore())
			.AfterMap((src, dest, context) =>
			{
				var employerId = context.Items["EmployerId"] as Guid?;
				if (employerId != null)
				{
					dest.EmployerId = employerId.Value;
				}
			});

		//CreateMap<UpdateJobCommand, Job>()
		//	.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.JobId))
		//	.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
		//	.ForMember(dest => dest.JobCategoryId, opt => opt.MapFrom(src => (Guid?)src.JobCategoryId))
		//	.ForMember(dest => dest.JobTypeId, opt => opt.MapFrom(src => (Guid?)src.JobTypeId))
		//	.ForMember(dest => dest.ExperienceLevelId, opt => opt.MapFrom(src => (Guid?)src.ExperienceLevelId))
		//	.ForMember(dest => dest.MinEducationId, opt => opt.MapFrom(src => (Guid?)src.MinEducationId))
		//	.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
		//	.ForMember(dest => dest.Responsibilities, opt => opt.MapFrom(src => src.Responsibilities))
		//	.ForMember(dest => dest.Requirements, opt => opt.MapFrom(src => src.Requirements))
		//	.ForMember(dest => dest.MinSalary, opt => opt.MapFrom(src => (decimal?)src.MinSalary))
		//	.ForMember(dest => dest.MaxSalary, opt => opt.MapFrom(src => (decimal?)src.MaxSalary))
		//	.ForMember(dest => dest.SalaryPeriod, opt => opt.MapFrom(src => src.SalaryPeriod))
		//	.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
		//	.ForMember(dest => dest.IsSalaryNegotiable, opt => opt.MapFrom(src => (bool?)src.IsSalaryNegotiable))
		//	.ForMember(dest => dest.LocationCity, opt => opt.MapFrom(src => src.LocationCity))
		//	.ForMember(dest => dest.LocationState, opt => opt.MapFrom(src => src.LocationState))
		//	.ForMember(dest => dest.LocationCountry, opt => opt.MapFrom(src => src.LocationCountry))
		//	.ForMember(dest => dest.IsRemote, opt => opt.MapFrom(src => (bool?)src.IsRemote))
		//	.ForMember(dest => dest.AllowsWorkFromHome, opt => opt.MapFrom(src => (bool?)src.AllowsWorkFromHome))
		//	.ForMember(dest => dest.ApplicationDeadline, opt => opt.MapFrom(src => (long?)src.ApplicationDeadline))
		//	.ForMember(dest => dest.IsFeatured, opt => opt.MapFrom(src => (bool?)src.IsFeatured))
		//	.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.Now))

		//	// Ignore navigation properties to prevent mapping errors
		//	.ForMember(dest => dest.Employer, opt => opt.Ignore())
		//	.ForMember(dest => dest.ExperienceLevel, opt => opt.Ignore())
		//	.ForMember(dest => dest.JobApplications, opt => opt.Ignore())
		//	.ForMember(dest => dest.JobCategory, opt => opt.Ignore())
		//	.ForMember(dest => dest.JobSkills, opt => opt.Ignore())
		//	.ForMember(dest => dest.JobType, opt => opt.Ignore())
		//	.ForMember(dest => dest.MinEducation, opt => opt.Ignore())
		//	.ForMember(dest => dest.SavedJobs, opt => opt.Ignore())
		//	.ForMember(dest => dest.JobAlerts, opt => opt.Ignore())
		//	.ForMember(dest => dest.EmployerId, opt => opt.Ignore())
		//	.AfterMap((src, dest, context) =>
		//	{
		//		var employerId = context.Items["EmployerId"] as Guid?;
		//		if (employerId != null)
		//		{
		//			dest.EmployerId = employerId.Value;
		//		}
		//	});

		CreateMap<Job, PostedJobDto>()
					.ForMember(dest => dest.JobType, opt =>
						opt.MapFrom(src => src.JobType != null ? src.JobType.TypeName : string.Empty))
					.ForMember(dest => dest.DaysRemaing, opt =>
						opt.MapFrom(src =>
							src.ApplicationDeadline.HasValue
							? (int)(DateTimeOffset.FromUnixTimeSeconds(src.ApplicationDeadline.Value).Date - DateTime.UtcNow.Date).TotalDays
							: 0))
					.ForMember(dest => dest.IsActive, opt =>
						opt.MapFrom(src => src.IsActive ?? false))
					.ForMember(dest => dest.ApplicationsCount, opt =>
						opt.MapFrom(src => src.ApplicationsCount ?? 0));
		CreateMap<PageResult<Job>, PageResult<PostedJobDto>>();
		CreateMap<PageResult<Job>, PageResult<CommonJob>>();
		CreateMap<Job, CommonJob>();
	}
}