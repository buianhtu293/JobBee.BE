using AutoMapper;
using JobBee.Application.Features.Company.Queries.GetTopCompany;
using JobBee.Application.Features.Employer.Queries.GetAllEmployer;
using JobBee.Domain.Entities;
using JobBee.Shared.Paginators;

namespace JobBee.Application.MappingProfiles
{
	public class EmployerProfile : Profile
	{
        public EmployerProfile()
        {
			CreateMap<Employer, EmployerPageResultDto>()
				.ForMember(des => des.UserName, opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(des => des.IndustryName, opt => opt.MapFrom(src => src.Industry.IndustryName))
				.ForMember(des => des.SizeRange, opt => opt.MapFrom(src => src.CompanySize.SizeRange));

			CreateMap<Employer, TopCompanyDto>();
			CreateMap<PageResult<Employer>, PageResult<TopCompanyDto>>();
		}
    }
}
