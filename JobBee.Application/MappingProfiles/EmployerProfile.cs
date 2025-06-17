using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.Employer.Queries.GetAllEmployer;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class EmployerProfile : Profile
	{
        public EmployerProfile()
        {
            CreateMap<Employer, EmployerPageResultDto>().ReverseMap();
        }
    }
}
