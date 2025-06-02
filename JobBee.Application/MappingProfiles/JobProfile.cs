using AutoMapper;
using JobBee.Application.Features.Job.Commands.CreateJob;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Domain.Entities;
using JobBee.Shared.Ultils;

namespace JobBee.Application.MappingProfiles;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Job, JobDto>().ReverseMap();
        CreateMap<CreateJobCommand, Job>().ForMember(des => des.ApplicationDeadline, 
            opt => opt.MapFrom(src => src.ApplicationDeadline.ConvertToDate()));
    }
}