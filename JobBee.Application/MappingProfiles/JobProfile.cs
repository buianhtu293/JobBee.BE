using AutoMapper;
using JobBee.Application.Features.Job.Commands.CreateJob;
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
			.ForMember(dest => dest.CompanyLogo, opt  => opt.MapFrom(src => src.Employer!.CompanyLogo))
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
		//CreateMap<List<Job>, List<PostedJobDto>>();
		CreateMap<PageResult<Job>, PageResult<PostedJobDto>>();
		CreateMap<PageResult<Job>, PageResult<CommonJob>>();
		CreateMap<Job, CommonJob>();
	}
}