using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.ExperienceLevel.Commands.CreateExperienceLevel;
using JobBee.Application.Features.ExperienceLevel.Commands.UpdateExperienceLevel;
using JobBee.Application.Features.ExperienceLevel.Queries.GetAllExperienceLevel;
using JobBee.Application.Features.ExperienceLevel.Queries.GetExperienceLevelDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class ExperienceLevelProfile : Profile
	{
        public ExperienceLevelProfile()
        {
            CreateMap<ExperienceLevel, CreateExperienceLevelCommand>().ReverseMap();
            CreateMap<ExperienceLevel, CreateExperienceLevelDto>().ReverseMap();

            CreateMap<ExperienceLevel, UpdateExperienceLevelCommand>().ReverseMap();
            CreateMap<ExperienceLevel, UpdateExperienceLevelDto>().ReverseMap();

            CreateMap<ExperienceLevel, ExperienceLevelDto>().ReverseMap();

            CreateMap<EducationLevel, ExperienceLevelDetailDto>().ReverseMap();
        }
    }
}
