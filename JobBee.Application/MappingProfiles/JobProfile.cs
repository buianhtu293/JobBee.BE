using AutoMapper;
using JobBee.Application.Features.Job.Commands.CreateJob;
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
        CreateMap<CreateJobCommand, Job>().ForMember(des => des.ApplicationDeadline, 
            opt => opt.MapFrom(src => src.ApplicationDeadline.ConvertToDate()))
            .ForMember(des => des.ExpiresAt, opt => opt.MapFrom(src => src.ExpireAt.ConvertToDateTime()));
        CreateMap<Job, PostedJobDto>()
            .ForMember(des => des.DaysRemaing, opt =>
                opt.MapFrom(src => src.ApplicationDeadline!.Value.DifferenceDays(DateOnly.FromDateTime(DateTime.Now))))
            .ForMember(des => des.JobType, opt =>
                opt.MapFrom(src => src.JobType!.TypeName));
        CreateMap<PageResult<Job>, PageResult<PostedJobDto>>();
    }
}