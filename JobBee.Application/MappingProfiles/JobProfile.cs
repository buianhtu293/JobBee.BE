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
        CreateMap<CreateJobCommand, Job>();
        CreateMap<PageResult<Job>, PageResult<PostedJobDto>>();
    }
}