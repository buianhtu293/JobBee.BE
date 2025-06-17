using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.Industry.Commands.CreateIndustry;
using JobBee.Application.Features.Industry.Commands.UpdateIndustry;
using JobBee.Application.Features.Industry.Queries.GetAllIndustry;
using JobBee.Application.Features.Industry.Queries.GetIndustryDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class IndustryProfile : Profile
	{
        public IndustryProfile()
        {
            CreateMap<Industry, CreateIndustryCommand>().ReverseMap();
            CreateMap<Industry, CreateIndustryDto>().ReverseMap();

            CreateMap<Industry, UpdateIndustryCommand>().ReverseMap();
            CreateMap<Industry, UpdateIndustryDto>().ReverseMap();

            CreateMap<Industry, IndustryDto>().ReverseMap();

            CreateMap<Industry, IndustryDetailDto>().ReverseMap();
        }
    }
}
