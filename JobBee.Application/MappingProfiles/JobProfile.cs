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
        CreateMap<Job, JobDto>().ReverseMap();
        CreateMap<CreateJobCommand, Job>();
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