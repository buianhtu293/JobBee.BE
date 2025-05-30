using AutoMapper;
using JobBee.Api.Models;
using JobBee.Application.Features.Job.Commands.CreateJob;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Job, JobDto>().ReverseMap();
        CreateMap<Job, CreateJobRequestDto>().ReverseMap();
    }
}