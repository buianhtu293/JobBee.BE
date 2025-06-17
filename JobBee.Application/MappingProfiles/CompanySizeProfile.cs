using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.CompanySize.Commands.CreateCompanySize;
using JobBee.Application.Features.CompanySize.Commands.UpdateCompanySize;
using JobBee.Application.Features.CompanySize.Queries.GetAllCompanySize;
using JobBee.Application.Features.CompanySize.Queries.GetCompanySizeDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class CompanySizeProfile : Profile
	{
        public CompanySizeProfile()
        {
            CreateMap<CompanySize, CreateCompanySizeCommand>().ReverseMap();
            CreateMap<CompanySize, CreateCompanySizeDto>().ReverseMap();

            CreateMap<CompanySize, UpdateCompanySizeCommand>().ReverseMap();
            CreateMap<CompanySize, UpdateCompanySizeDto>().ReverseMap();

            CreateMap<CompanySize, CompanySizeDto>().ReverseMap();

            CreateMap<CompanySize, CompanySizeDetailDto>().ReverseMap();
        }
    }
}
