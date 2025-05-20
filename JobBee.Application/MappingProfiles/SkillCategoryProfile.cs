using AutoMapper;
using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
using JobBee.Api.Models;

namespace JobBee.Application.MappingProfiles
{
	public class SkillCategoryProfile : Profile
	{
		public SkillCategoryProfile() 
		{
			CreateMap<SkillCategoryDto, SkillCategory>().ReverseMap();
		}
	}
}
