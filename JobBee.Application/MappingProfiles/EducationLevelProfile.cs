using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.EducationLevel.Commands.CreateEducationLevel;
using JobBee.Application.Features.EducationLevel.Commands.UpdateEducationLevel;
using JobBee.Application.Features.EducationLevel.Queries.GetAllEducationLevel;
using JobBee.Application.Features.EducationLevel.Queries.GetEducationLevelDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
    public class EducationLevelProfile : Profile
	{
        public EducationLevelProfile()
        {
            CreateMap<EducationLevel, EducationLevelDto>().ReverseMap();

            CreateMap<EducationLevel, EducationLevelDetailDto>().ReverseMap();

            CreateMap<EducationLevel, CreateEducationLevelCommand>().ReverseMap();
            CreateMap<EducationLevel, CreatEducationLevelDto>().ReverseMap();

            CreateMap<EducationLevel, UpdateEducationLevelCommand>().ReverseMap();
            CreateMap<EducationLevel, UpdateEducationLevelDto>().ReverseMap();
        }
    }
}
